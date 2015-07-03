#region File Header

// ====================================================================
// Copyright (c) 2015, James Alexander Green (JamSoft)
// Some Rights Reserved :)
// ====================================================================
// File Details
// Solution Name: JamSoft.CALDemo2
// Project Name : JamSoft.CALDemo.Modules.SettingsManager
// File Name    : PropertiesCollection.cs
// Created     : 03/07/2015 22:47
// ====================================================================
#endregion

namespace JamSoft.CALDemo.Modules.SettingsManager
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class PropertiesCollection : IXmlSerializable
    {
        /// <summary>The _keys</summary>
        private List<string> _keys = new List<string>();

        /// <summary>The _properties</summary>
        private NameValueCollection _properties = new NameValueCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertiesCollection"/> class.
        /// </summary>
        internal PropertiesCollection()
        {
        }

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema" /> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" /> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>Generates an object from its XML representation.</summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader" /> stream from which the object is deserialized.</param>
        public void ReadXml(XmlReader reader)
        {
            _properties = new NameValueCollection();

            reader.Read();
            while (reader.MoveToNextAttribute())
            {
                _properties.Add(reader.Name, reader.Value);
            }

            _keys = _properties.AllKeys.ToList();
        }

        /// <summary>Converts an object into its XML representation.</summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter" /> stream to which the object is serialized.</param>
        public void WriteXml(XmlWriter writer)
        {
            foreach (string key in _properties.Keys)
            {
                writer.WriteStartElement("property");
                var value = _properties[key];
                writer.WriteAttributeString(key, value);
                writer.WriteEndElement();
            }
        }

        /// <summary>Sets the setting.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void SetSetting(string key, object value)
        {
            if (!_keys.Contains(key))
            {
                _properties.Add(key, value.ToString());
                _keys.Add(key);
            }
            else
            {
                _properties.Set(key, value.ToString());
            }
        }

        /// <summary>Gets the setting value.</summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public object GetSettingValue(string key)
        {
            return _properties[key];
        }
    }
}