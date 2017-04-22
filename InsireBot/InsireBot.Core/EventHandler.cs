﻿using System;

namespace Maple.Core
{
    public delegate void LogMessageReceivedEventHandler(object sender, LogMessageReceivedEventEventArgs e);
    public class LogMessageReceivedEventEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        /// <autogeneratedoc />
        public string Message { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogMessageReceivedEventEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <autogeneratedoc />
        public LogMessageReceivedEventEventArgs(string message)
        {
            Message = message;
        }
    }

    public delegate void FileSystemInfoChangedEventHandler(object sender, FileSystemInfoChangedEventArgs e);
    public class FileSystemInfoChangedEventArgs : EventArgs
    {
        public IFileSystemInfo FileSystemInfo { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemInfoChangedEventArgs"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <autogeneratedoc />
        public FileSystemInfoChangedEventArgs(IFileSystemInfo item)
        {
            FileSystemInfo = item;
        }
    }
}