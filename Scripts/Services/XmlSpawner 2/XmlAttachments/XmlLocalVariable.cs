using System;

namespace Server.Engines.XmlSpawner2
{
    public class XmlLocalVariable : XmlAttachment
    {
        private string m_DataValue = null;// default data

        // a serial constructor is REQUIRED
        public XmlLocalVariable(ASerial serial)
            : base(serial)
        {
        }

        [Attachable]
        public XmlLocalVariable(string name)
        {
            this.Name = name;
            this.Data = String.Empty;
        }

        [Attachable]
        public XmlLocalVariable(string name, string data)
        {
            this.Name = name;
            this.Data = data;
        }

        [Attachable]
        public XmlLocalVariable(string name, string data, double expiresin)
        {
            this.Name = name;
            this.Data = data;
            this.Expiration = TimeSpan.FromMinutes(expiresin);
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string Data
        {
            get
            {
                return this.m_DataValue;
            }
            set
            {
                this.m_DataValue = value;
            }
        }
        // These are the various ways in which the message attachment can be constructed.  
        // These can be called via the [addatt interface, via scripts, via the spawner ATTACH keyword.
        // Other overloads could be defined to handle other types of arguments
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
            // version 0
            writer.Write((string)this.m_DataValue);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            // version 0
            this.m_DataValue = reader.ReadString();
        }

        public override string OnIdentify(Mobile from)
        {
            if (from == null || from.AccessLevel == AccessLevel.Player)
                return null;

            if (this.Expiration > TimeSpan.Zero)
            {
                return String.Format("{2} = {0} : expires in {1} mins", this.Data, this.Expiration.TotalMinutes, this.Name);
            }
            else
            {
                return String.Format("{1} = {0}", this.Data, this.Name);
            }
        }
    }
}