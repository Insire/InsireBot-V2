﻿using System;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Maple.Domain;
using Maple.Localization.Properties;

namespace Maple.Core
{
    public class FileSystemViewModel : ObservableObject
    {
        private readonly IMessenger _messenger;

        protected readonly BusyStack _busyStack;

        public ICommand SelectCommand { get; private set; }

        private IRangeObservableCollection<IFileSystemInfo> _selectedItems;
        public IRangeObservableCollection<IFileSystemInfo> SelectedItems
        {
            get { return _selectedItems; }
            private set { SetValue(ref _selectedItems, value); }
        }

        private IRangeObservableCollection<IFileSystemInfo> _selectedDetailItems;
        public IRangeObservableCollection<IFileSystemInfo> SelectedDetailItems
        {
            get { return _selectedDetailItems; }
            set { SetValue(ref _selectedDetailItems, value); }
        }

        private IRangeObservableCollection<MapleDrive> _drives;
        public IRangeObservableCollection<MapleDrive> Drives
        {
            get { return _drives; }
            private set { SetValue(ref _drives, value); }
        }

        private MapleFileSystemContainerBase _selectedItem;
        public MapleFileSystemContainerBase SelectedItem
        {
            get { return _selectedItem; }
            set { SetValue(ref _selectedItem, value, OnChanged: OnSelectedItemChanged); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            private set { SetValue(ref _isBusy, value); }
        }

        private string _filter;
        public string Filter
        {
            get { return _filter; }
            set { SetValue(ref _filter, value, OnChanged: () => SelectedItem.OnFilterChanged(Filter)); }
        }

        private bool _displayListView;
        public bool DisplayListView
        {
            get { return _displayListView; }
            set { SetValue(ref _displayListView, value); }
        }

        private FileSystemViewModel()
        {
            _busyStack = new BusyStack();
            _busyStack.OnChanged += (hasItems) => IsBusy = hasItems;

            SelectCommand = new RelayCommand<IFileSystemInfo>(SetSelectedItem, CanSetSelectedItem);
        }

        public FileSystemViewModel(IMessenger messenger)
            : this()
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger), $"{nameof(messenger)} {Resources.IsRequired}");

            using (_busyStack.GetToken())
            {
                DisplayListView = false;

                Drives = new RangeObservableCollection<MapleDrive>();
                SelectedItems = new RangeObservableCollection<IFileSystemInfo>();
                SelectedDetailItems = new RangeObservableCollection<IFileSystemInfo>();

                var drives = DriveInfo.GetDrives()
                                        .Where(p => p.IsReady && p.DriveType != DriveType.CDRom && p.DriveType != DriveType.Unknown)
                                        .Select(p => new MapleDrive(p, new FileSystemDepth(0)))
                                        .ToList();
                Drives.AddRange(drives);
            }
        }

        private void OnSelectedItemChanged()
        {
            SelectedItem.Load();
            SelectedItem.LoadMetaData();

            _messenger.Publish(new FileSystemInfoChangedMessage(this, SelectedItem));
        }

        /// <summary>
        /// Sets the selected item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <autogeneratedoc />
        public void SetSelectedItem(IFileSystemInfo item)
        {
            var value = item as MapleFileSystemContainerBase;

            if (value == null)
                return;

            SelectedItem = value;
            SelectedItem.ExpandPath();
            SelectedItem.Parent.IsSelected = true;
        }

        private bool CanSetSelectedItem(IFileSystemInfo item)
        {
            var value = item as MapleFileSystemContainerBase;

            return value != null && value != SelectedItem;
        }
    }
}
