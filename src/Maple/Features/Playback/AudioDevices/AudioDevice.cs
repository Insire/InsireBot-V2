using System;
using Maple.Domain;
using MvvmScarletToolkit.Observables;

namespace Maple
{
    public class AudioDevice : ObservableObject
    {
        private string _osId;
        public string OsId
        {
            get { return _osId; }
            private set { SetValue(ref _osId, value); }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            private set { SetValue(ref _id, value); }
        }

        private int _sequence;
        public int Sequence
        {
            get { return _sequence; }
            set { SetValue(ref _sequence, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetValue(ref _isSelected, value); }
        }

        private DeviceType _deviceType;
        public DeviceType DeviceType
        {
            get { return _deviceType; }
            protected set { SetValue(ref _deviceType, value); }
        }

        private string _createdBy;
        public string CreatedBy
        {
            get { return _createdBy; }
            private set { SetValue(ref _createdBy, value); }
        }

        private string _updatedBy;
        public string UpdatedBy
        {
            get { return _updatedBy; }
            private set { SetValue(ref _updatedBy, value); }
        }

        private DateTime _updatedOn;
        public DateTime UpdatedOn
        {
            get { return _updatedOn; }
            private set { SetValue(ref _updatedOn, value); }
        }

        private DateTime _createdOn;
        public DateTime CreatedOn
        {
            get { return _createdOn; }
            private set { SetValue(ref _createdOn, value); }
        }

        protected AudioDevice(string osIdentifier)
        {
            if (string.IsNullOrWhiteSpace(osIdentifier))
            {
                throw new ArgumentException("Can't be Null or WhiteSpace", nameof(osIdentifier));
            }

            OsId = osIdentifier;
        }

        public AudioDevice(AudioDevice audioDevice)
        {
            Id = audioDevice.Id;
            Name = audioDevice.Name;
            Sequence = audioDevice.Sequence;

            DeviceType = audioDevice.DeviceType;

            CreatedBy = audioDevice.CreatedBy;
            CreatedOn = audioDevice.CreatedOn;
            UpdatedBy = audioDevice.UpdatedBy;
            UpdatedOn = audioDevice.UpdatedOn;
        }

        public void AssignModel(AudioDeviceModel audioDeviceModel)
        {
            Id = audioDeviceModel.Id;
            Name = audioDeviceModel.Name;
            Sequence = audioDeviceModel.Sequence;

            CreatedBy = audioDeviceModel.CreatedBy;
            CreatedOn = audioDeviceModel.CreatedOn;
            UpdatedBy = audioDeviceModel.UpdatedBy;
            UpdatedOn = audioDeviceModel.UpdatedOn;
        }
    }
}