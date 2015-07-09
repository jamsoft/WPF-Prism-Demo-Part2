#region File Header
// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SkinManager.Core
// File Name    : SkinException.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SkinManager.Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The skin exception class
    /// </summary>
    [Serializable]
    public class SkinException : Exception
    {
        /// <summary>The _skinname</summary>
        private string _skinname;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinException"/> class.
        /// </summary>
        public SkinException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SkinException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public SkinException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException"><paramref>
        ///         <name>name</name>
        ///     </paramref>
        ///     is null. </exception>
        /// <exception cref="InvalidCastException">The value associated with <paramref>
        ///         <name>name</name>
        ///     </paramref>
        ///     cannot be converted to a <see cref="T:System.String" />. </exception>
        /// <exception cref="SerializationException">An element with the specified name is not found in the current instance. </exception>
        protected SkinException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                _skinname = info.GetString("_skinname");
            }
        }

        /// <summary>Gets or sets the name of the skin.</summary>
        /// <value>The name of the skin.</value>
        public string SkinName
        {
            get
            {
                return _skinname;
            }

            set
            {
                _skinname = value;
            }
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter" />
        /// </PermissionSet>
        /// <exception cref="ArgumentNullException"><paramref>
        ///         <name>name</name>
        ///     </paramref>
        ///     is null. </exception>
        /// <exception cref="SerializationException">A value has already been associated with <paramref>
        ///         <name>name</name>
        ///     </paramref>
        /// . </exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("_skinname", _skinname);
        }
    }
}