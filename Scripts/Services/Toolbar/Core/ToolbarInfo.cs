﻿using System;
using System.Collections.Generic;
using Server;
using CustomsFramework;

namespace Services.Toolbar.Core
{
    public partial class ToolbarInfo
    {
        private int _Font, _Skin;
        private bool _Phantom, _Stealth, _Reverse, _Lock;
        private Point2D _Dimensions;
        private List<string> _Entries = new List<string>();
        private List<Point3D> _Points = new List<Point3D>();

        public ToolbarInfo(Point2D dimensions, List<string> entries, int skin, List<Point3D> points,
            int font, bool[] switches)
        {
            _Dimensions = dimensions;
            _Entries = entries;
            _Skin = skin;
            _Points = points;
            _Font = font;
            _Phantom = switches[0];
            _Stealth = switches[1];
            _Reverse = switches[2];
            _Lock = switches[3];
        }

        public int Font
        {
            get
            {
                return _Font;
            }
            set
            {
                _Font = value;
            }
        }

        public int Skin
        {
            get
            {
                return _Skin;
            }
            set
            {
                _Skin = value;
            }
        }

        public bool Phantom
        {
            get
            {
                return _Phantom;
            }
            set
            {
                _Phantom = value;
            }
        }

        public bool Stealth
        {
            get
            {
                return _Stealth;
            }
            set
            {
                _Stealth = value;
            }
        }

        public bool Reverse
        {
            get
            {
                return _Reverse;
            }
            set
            {
                _Reverse = value;
            }
        }

        public bool Lock
        {
            get
            {
                return _Lock;
            }
            set
            {
                _Lock = value;
            }
        }

        public int Rows
        {
            get
            {
                return _Dimensions.X;
            }
            set
            {
                _Dimensions.X = value;
            }
        }

        public int Collumns
        {
            get
            {
                return _Dimensions.Y;
            }
            set
            {
                _Dimensions.Y = value;
            }
        }

        public List<string> Entries
        {
            get
            {
                return _Entries;
            }
            set
            {
                _Entries = value;
            }
        }

        public List<Point3D> Points
        {
            get
            {
                return _Points;
            }
            set
            {
                _Points = value;
            }
        }

        public static ToolbarInfo CreateNew(Mobile from)
        {
            Point2D dimensions = DefaultDimensions(from.AccessLevel);
            List<string> entries = DefaultEntries(from.AccessLevel);
            List<Point3D> points = new List<Point3D>();

            for (int i = entries.Count; i <= 135; i++)
                entries.Add("-*UNUSED*-");

            return new ToolbarInfo(dimensions, entries, 0, points, 0, new bool[] { true, false, false, true });
        }

        public static List<string> DefaultEntries(AccessLevel level)
        {
            List<string> entries = new List<string>();

            switch (level)
            {
                case AccessLevel.Player:
                    {
                        break;
                    }
                case AccessLevel.VIP:
                    {
                        break;
                    }
                case AccessLevel.Counselor:
                    {
                        entries.Add("[GMBody"); entries.Add("[StaffRunebook");
                        entries.Add("[SpeedBoost"); entries.Add("[M Tele");
                        entries.Add("[Where"); entries.Add("[Who");

                        break;
                    }
                case AccessLevel.Decorator:
                    {
                        entries.Add("[GMBody"); entries.Add("[StaffRunebook");
                        entries.Add("[SpeedBoost"); entries.Add("[M Tele");
                        entries.Add("[Where"); entries.Add("[Who");

                        for (int j = 0; j < 3; j++)
                            entries.Add("-*UNUSED*-");

                        entries.Add("[Add"); entries.Add("[Remove");
                        entries.Add("[Move"); entries.Add("[ShowArt");
                        entries.Add("[Get ItemID"); entries.Add("[Get Hue");

                        break;
                    }
                case AccessLevel.Spawner:
                    {
                        entries.Add("[GMBody"); entries.Add("[StaffRunebook");
                        entries.Add("[SpeedBoost"); entries.Add("[M Tele");
                        entries.Add("[Where"); entries.Add("[Who");

                        for (int j = 0; j < 3; j++)
                            entries.Add("-*UNUSED*-");

                        entries.Add("[Add"); entries.Add("[Remove");
                        entries.Add("[XmlAdd"); entries.Add("[XmlFind");
                        entries.Add("[XmlShow"); entries.Add("[XmlHide");

                        break;
                    }
                case AccessLevel.GameMaster:
                    {
                        entries.Add("[GMBody"); entries.Add("[StaffRunebook");
                        entries.Add("[SpeedBoost"); entries.Add("[M Tele");
                        entries.Add("[Where"); entries.Add("[Who");

                        for (int j = 0; j < 3; j++)
                            entries.Add("-*UNUSED*-");

                        entries.Add("[Add"); entries.Add("[Remove");
                        entries.Add("[Props"); entries.Add("[Move");
                        entries.Add("[Kill"); entries.Add("[Follow");

                        break;
                    }
                case AccessLevel.Seer:
                    {
                        goto case AccessLevel.GameMaster;
                    }
                case AccessLevel.Administrator:
                    {
                        entries.Add("[Admin"); entries.Add("[StaffRunebook");
                        entries.Add("[SpeedBoost"); entries.Add("[M Tele");
                        entries.Add("[Where"); entries.Add("[Who");

                        for (int j = 0; j < 3; j++)
                            entries.Add("-*UNUSED*-");

                        entries.Add("[Props"); entries.Add("[Move");
                        entries.Add("[Add"); entries.Add("[Remove");
                        entries.Add("[ViewEquip"); entries.Add("[Kill");

                        break;
                    }
                case AccessLevel.Developer:
                    {
                        goto case AccessLevel.Administrator;
                    }
                case AccessLevel.CoOwner:
                    {
                        goto case AccessLevel.Administrator;
                    }
                case AccessLevel.Owner:
                    {
                        goto case AccessLevel.Administrator;
                    }
            }
            return entries;
        }

        public static Point2D DefaultDimensions(AccessLevel level)
        {
            Point2D dimensions = new Point2D();

            switch (level)
            {
                case AccessLevel.Player:
                    {
                        dimensions.X = 0; dimensions.Y = 0;
                        break;
                    }
                case AccessLevel.VIP:
                    {
                        goto case AccessLevel.Player;
                    }
                case AccessLevel.Counselor:
                    {
                        dimensions.X = 6; dimensions.Y = 1;
                        break;
                    }
                case AccessLevel.Decorator:
                    {
                        dimensions.X = 6; dimensions.Y = 2;
                        break;
                    }
                case AccessLevel.Spawner:
                    {
                        goto case AccessLevel.Decorator;
                    }
                case AccessLevel.GameMaster:
                    {
                        goto case AccessLevel.Decorator;
                    }
                case AccessLevel.Seer:
                    {
                        goto case AccessLevel.Decorator;
                    }
                case AccessLevel.Administrator:
                    {
                        goto case AccessLevel.Decorator;
                    }
                case AccessLevel.Developer:
                    {
                        goto case AccessLevel.Decorator;
                    }
                case AccessLevel.CoOwner:
                    {
                        goto case AccessLevel.Decorator;
                    }
                case AccessLevel.Owner:
                    {
                        goto case AccessLevel.Decorator;
                    }
            }
            return dimensions;
        }

        public ToolbarInfo(GenericReader reader)
        {
            Deserialize(reader);
        }

        public void Serialize(GenericWriter writer)
        {
            Utilities.WriteVersion(writer, 0);

            writer.Write(this._Font);
            writer.Write(this._Phantom);
            writer.Write(this._Stealth);
            writer.Write(this._Reverse);
            writer.Write(this._Lock);

            writer.Write(this._Dimensions);

            writer.Write(this._Entries.Count);

            for (int i = 0; i < this._Entries.Count; i++)
                writer.Write(this._Entries[i]);

            writer.Write(this._Skin);

            writer.Write(this._Points.Count);

            for (int i = 0; i < this._Points.Count; i++)
                writer.Write(this._Points[i]);
        }

        private void Deserialize(GenericReader reader)
        {
            int version = reader.ReadInt();

            _Dimensions = new Point2D();
            _Entries = new List<string>();
            _Points = new List<Point3D>();

            switch (version)
            {
                case 0:
                    {
                        _Font = reader.ReadInt();
                        _Phantom = reader.ReadBool();
                        _Stealth = reader.ReadBool();
                        _Reverse = reader.ReadBool();
                        _Lock = reader.ReadBool();

                        _Dimensions = reader.ReadPoint2D();
                        
                        int count = reader.ReadInt();

                        for (int i = 0; i < count; i++)
                            _Entries.Add(reader.ReadString());

                        _Skin = reader.ReadInt();

                        count = reader.ReadInt();

                        for (int i = 0; i < count; i++)
                            _Points.Add(reader.ReadPoint3D());

                        break;
                    }
            }
        }
    }
}
