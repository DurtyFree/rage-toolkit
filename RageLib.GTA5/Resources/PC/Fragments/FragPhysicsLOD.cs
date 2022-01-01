// Copyright © Neodymium, carmineos and contributors. See LICENSE.md in the repository root for more information.

using RageLib.Resources.Common;
using RageLib.Resources.GTA5.PC.Bounds;
using System.Collections.Generic;
using System.Numerics;

namespace RageLib.Resources.GTA5.PC.Fragments
{
    // pgBase
    // fragPhysicsLOD
    public class FragPhysicsLOD : PgBase64
    {
        public override long BlockLength => 0x130;

        // structure data
        public uint Unknown_10h; // 0x00000000
        public uint Unknown_14h;
        public uint Unknown_18h;
        public uint Unknown_1Ch;
        public ulong ArticulatedBodyTypePointer;
        public ulong Unknown_28h_Pointer;
        public Vector4 Unknown_30h;
        public Vector4 Unknown_40h;
        public Vector4 Unknown_50h; // unbrokenCGOffset ?
        public Vector4 DampingLinearC;
        public Vector4 DampingLinearV;
        public Vector4 DampingLinearV2;
        public Vector4 DampingAngularC;
        public Vector4 DampingAngularV;
        public Vector4 DampingAngularV2;
        public ulong GroupNamesPointer;
        public ulong GroupsPointer;
        public ulong ChildrenPointer;
        public ulong PristineArchetypePointer;
        public ulong DamagedArchetypePointer;
        public ulong BoundPointer;
        public ulong PristineAngInertiaPointer;
        public ulong DamagedAngInertiaPointer;
        public ulong ChildrenTransformsPointer;
        public ulong Unknown_108h_Pointer;
        public ulong Unknown_110h_Pointer;
        public byte Count1;
        public byte Count2;
        public byte GroupsCount;
        public byte Unknown_11Bh;
        public byte Unknown_11Ch;
        public byte ChildrenCount;
        public byte Count3;
        public byte Unknown_11Fh; // 0x00
        public ulong Unknown_120h; // 0x0000000000000000
        public ulong Unknown_128h; // 0x0000000000000000

        // reference data
        public ArticulatedBodyType ArticulatedBodyType;
        public SimpleArray<float> Unknown_28h_Data;
        public FragTypeGroupNames GroupNames;
        public ResourcePointerArray64<FragTypeGroup> Groups;
        public ResourcePointerArray64<FragTypeChild> Children;
        public Archetype PristineArchetype;
        public Archetype DamagedArchetype;
        public Bound Bound;
        public SimpleArray<Vector4> PristineAngInertia;
        public SimpleArray<Vector4> DamagedAngInertia;
        public Unknown_F_001 ChildrenTransforms;
        public SimpleArray<byte> Unknown_108h_Data;
        public SimpleArray<byte> Unknown_110h_Data;

        /// <summary>
        /// Reads the data-block from a stream.
        /// </summary>
        public override void Read(ResourceDataReader reader, params object[] parameters)
        {
            base.Read(reader, parameters);

            // read structure data
            this.Unknown_10h = reader.ReadUInt32();
            this.Unknown_14h = reader.ReadUInt32();
            this.Unknown_18h = reader.ReadUInt32();
            this.Unknown_1Ch = reader.ReadUInt32();
            this.ArticulatedBodyTypePointer = reader.ReadUInt64();
            this.Unknown_28h_Pointer = reader.ReadUInt64();
            this.Unknown_30h = reader.ReadVector4();
            this.Unknown_40h = reader.ReadVector4();
            this.Unknown_50h = reader.ReadVector4();
            this.DampingLinearC = reader.ReadVector4();
            this.DampingLinearV = reader.ReadVector4();
            this.DampingLinearV2 = reader.ReadVector4();
            this.DampingAngularC = reader.ReadVector4();
            this.DampingAngularV = reader.ReadVector4();
            this.DampingAngularV2 = reader.ReadVector4();
            this.GroupNamesPointer = reader.ReadUInt64();
            this.GroupsPointer = reader.ReadUInt64();
            this.ChildrenPointer = reader.ReadUInt64();
            this.PristineArchetypePointer = reader.ReadUInt64();
            this.DamagedArchetypePointer = reader.ReadUInt64();
            this.BoundPointer = reader.ReadUInt64();
            this.PristineAngInertiaPointer = reader.ReadUInt64();
            this.DamagedAngInertiaPointer = reader.ReadUInt64();
            this.ChildrenTransformsPointer = reader.ReadUInt64();
            this.Unknown_108h_Pointer = reader.ReadUInt64();
            this.Unknown_110h_Pointer = reader.ReadUInt64();
            this.Count1 = reader.ReadByte();
            this.Count2 = reader.ReadByte();
            this.GroupsCount = reader.ReadByte();
            this.Unknown_11Bh = reader.ReadByte();
            this.Unknown_11Ch = reader.ReadByte();
            this.ChildrenCount = reader.ReadByte();
            this.Count3 = reader.ReadByte();
            this.Unknown_11Fh = reader.ReadByte();
            this.Unknown_120h = reader.ReadUInt64();
            this.Unknown_128h = reader.ReadUInt64();

            // read reference data
            this.ArticulatedBodyType = reader.ReadBlockAt<ArticulatedBodyType>(
                this.ArticulatedBodyTypePointer // offset
            );
            this.Unknown_28h_Data = reader.ReadBlockAt<SimpleArray<float>>(
                this.Unknown_28h_Pointer, // offset
                this.ChildrenCount
            );
            this.GroupNames = reader.ReadBlockAt<FragTypeGroupNames>(
                this.GroupNamesPointer, // offset
                this.GroupsCount
            );
            this.Groups = reader.ReadBlockAt<ResourcePointerArray64<FragTypeGroup>>(
                this.GroupsPointer, // offset
                this.GroupsCount
            );
            this.Children = reader.ReadBlockAt<ResourcePointerArray64<FragTypeChild>>(
                this.ChildrenPointer, // offset
                this.ChildrenCount
            );
            this.PristineArchetype = reader.ReadBlockAt<Archetype>(
                this.PristineArchetypePointer // offset
            );
            this.DamagedArchetype = reader.ReadBlockAt<Archetype>(
                this.DamagedArchetypePointer // offset
            );
            this.Bound = reader.ReadBlockAt<Bound>(
                this.BoundPointer // offset
            );
            this.PristineAngInertia = reader.ReadBlockAt<SimpleArray<Vector4>>(
                this.PristineAngInertiaPointer, // offset
                this.ChildrenCount
            );
            this.DamagedAngInertia = reader.ReadBlockAt<SimpleArray<Vector4>>(
                this.DamagedAngInertiaPointer, // offset
                this.ChildrenCount
            );
            this.ChildrenTransforms = reader.ReadBlockAt<Unknown_F_001>(
                this.ChildrenTransformsPointer // offset
            );
            this.Unknown_108h_Data = reader.ReadBlockAt<SimpleArray<byte>>(
                this.Unknown_108h_Pointer, // offset
                this.Count1
            );
            this.Unknown_110h_Data = reader.ReadBlockAt<SimpleArray<byte>>(
                this.Unknown_110h_Pointer, // offset
                this.Count2
            );
        }

        /// <summary>
        /// Writes the data-block to a stream.
        /// </summary>
        public override void Write(ResourceDataWriter writer, params object[] parameters)
        {
            base.Write(writer, parameters);

            // update structure data
            this.ArticulatedBodyTypePointer = (ulong)(this.ArticulatedBodyType != null ? this.ArticulatedBodyType.BlockPosition : 0);
            this.Unknown_28h_Pointer = (ulong)(this.Unknown_28h_Data != null ? this.Unknown_28h_Data.BlockPosition : 0);
            this.GroupNamesPointer = (ulong)(this.GroupNames != null ? this.GroupNames.BlockPosition : 0);
            this.GroupsPointer = (ulong)(this.Groups != null ? this.Groups.BlockPosition : 0);
            this.ChildrenPointer = (ulong)(this.Children != null ? this.Children.BlockPosition : 0);
            this.PristineArchetypePointer = (ulong)(this.PristineArchetype != null ? this.PristineArchetype.BlockPosition : 0);
            this.DamagedArchetypePointer = (ulong)(this.DamagedArchetype != null ? this.DamagedArchetype.BlockPosition : 0);
            this.BoundPointer = (ulong)(this.Bound != null ? this.Bound.BlockPosition : 0);
            this.PristineAngInertiaPointer = (ulong)(this.PristineAngInertia != null ? this.PristineAngInertia.BlockPosition : 0);
            this.DamagedAngInertiaPointer = (ulong)(this.DamagedAngInertia != null ? this.DamagedAngInertia.BlockPosition : 0);
            this.ChildrenTransformsPointer = (ulong)(this.ChildrenTransforms != null ? this.ChildrenTransforms.BlockPosition : 0);
            this.Unknown_108h_Pointer = (ulong)(this.Unknown_108h_Data != null ? this.Unknown_108h_Data.BlockPosition : 0);
            this.Unknown_110h_Pointer = (ulong)(this.Unknown_110h_Data != null ? this.Unknown_110h_Data.BlockPosition : 0);
            //this.vvv1 = (byte)(this.pxxxxx_2data != null ? this.pxxxxx_2data.Count : 0);
            //this.vvv2 = (byte)(this.pxxxxx_3data != null ? this.pxxxxx_3data.Count : 0);
            //this.GroupsCount = (byte)(this.Groups != null ? this.Groups.Count : 0);
            //this.ChildrenCount = (byte)(this.p1data != null ? this.p1data.Count : 0);

            // write structure data
            writer.Write(this.Unknown_10h);
            writer.Write(this.Unknown_14h);
            writer.Write(this.Unknown_18h);
            writer.Write(this.Unknown_1Ch);
            writer.Write(this.ArticulatedBodyTypePointer);
            writer.Write(this.Unknown_28h_Pointer);
            writer.Write(this.Unknown_30h);
            writer.Write(this.Unknown_40h);
            writer.Write(this.Unknown_50h);
            writer.Write(this.DampingLinearC);
            writer.Write(this.DampingLinearV);
            writer.Write(this.DampingLinearV2);
            writer.Write(this.DampingAngularC);
            writer.Write(this.DampingAngularV);
            writer.Write(this.DampingAngularV2);
            writer.Write(this.GroupNamesPointer);
            writer.Write(this.GroupsPointer);
            writer.Write(this.ChildrenPointer);
            writer.Write(this.PristineArchetypePointer);
            writer.Write(this.DamagedArchetypePointer);
            writer.Write(this.BoundPointer);
            writer.Write(this.PristineAngInertiaPointer);
            writer.Write(this.DamagedAngInertiaPointer);
            writer.Write(this.ChildrenTransformsPointer);
            writer.Write(this.Unknown_108h_Pointer);
            writer.Write(this.Unknown_110h_Pointer);
            writer.Write(this.Count1);
            writer.Write(this.Count2);
            writer.Write(this.GroupsCount);
            writer.Write(this.Unknown_11Bh);
            writer.Write(this.Unknown_11Ch);
            writer.Write(this.ChildrenCount);
            writer.Write(this.Count3);
            writer.Write(this.Unknown_11Fh);
            writer.Write(this.Unknown_120h);
            writer.Write(this.Unknown_128h);
        }

        /// <summary>
        /// Returns a list of data blocks which are referenced by this block.
        /// </summary>
        public override IResourceBlock[] GetReferences()
        {
            var list = new List<IResourceBlock>(base.GetReferences());
            if (ArticulatedBodyType != null) list.Add(ArticulatedBodyType);
            if (Unknown_28h_Data != null) list.Add(Unknown_28h_Data);
            if (Groups != null) list.Add(Groups);
            if (Children != null) list.Add(Children);
            if (PristineArchetype != null) list.Add(PristineArchetype);
            if (DamagedArchetype != null) list.Add(DamagedArchetype);
            if (Bound != null) list.Add(Bound);
            if (PristineAngInertia != null) list.Add(PristineAngInertia);
            if (DamagedAngInertia != null) list.Add(DamagedAngInertia);
            if (ChildrenTransforms != null) list.Add(ChildrenTransforms);
            if (Unknown_108h_Data != null) list.Add(Unknown_108h_Data);
            if (Unknown_110h_Data != null) list.Add(Unknown_110h_Data);
            if (GroupNames != null) list.Add(GroupNames);
            return list.ToArray();
        }
    }
}
