﻿// This file is automatic generated by script.  
// DO NOT EDIT DIRECTLY.   

using System;
using Konata.Core.Utils.Protobuf;

namespace Konata.Core.Packets.Oidb.Model;

internal abstract class OidbCmd0xe07 : OidbSSOPkg
{
    internal OidbCmd0xe07(uint svcType, ReqBody reqBody)
        : base(0xe07, svcType, null, (ProtoTreeRoot root) =>
        {
            root.AddTree(reqBody.BuildTree());
        })
    {

    }

    public class Coordinate : OidbStruct
    {
        // 0x08
        public uint? X;

        // 0x10
        public uint? Y;

        public override void Write(ProtoTreeRoot root)
        {
            root.AddLeafVar("08", X);
            root.AddLeafVar("10", Y);
        }
    }

    public class Language : OidbStruct
    {
        // 0x0A
        public string language;

        // 0x12
        public string languageDesc;

        public override void Write(ProtoTreeRoot root)
        {
            root.AddLeafString("0A", language);
            root.AddLeafString("12", languageDesc);
        }
    }

    public class OCRReqBody : OidbStruct
    {
        // 0x0A
        public string imageUrl;

        // 0x12
        public string languageType;

        // 0x1A
        public string scene;

        // 0x52
        public string originMd5;

        // 0x5A
        public string afterCompressMd5;

        // 0x60
        public uint? afterCompressFileSize;

        // 0x68
        public uint? afterCompressWeight;

        // 0x70
        public uint? afterCompressHeight;

        // 0x78
        public bool isCut;

        public override void Write(ProtoTreeRoot root)
        {
            root.AddLeafString("0A", imageUrl);
            root.AddLeafString("12", languageType);
            root.AddLeafString("1A", scene);
            root.AddLeafString("52", originMd5);
            root.AddLeafString("5A", afterCompressMd5);
            root.AddLeafVar("60", afterCompressFileSize);
            root.AddLeafVar("68", afterCompressWeight);
            root.AddLeafVar("70", afterCompressHeight);
            root.AddLeafVar("78", isCut ? 1 : 0);
        }
    }

    public class OCRRspBody : OidbStruct
    {
        // 0x0A
        public TextDetection textDetections;

        // 0x12
        public Language language;

        // 0x1A
        public string requestId;

        // 0xAA06
        public string ocrLanguageList;

        // 0xB206
        public string dstTranslateLanguageList;

        // 0x00
        public Language languageList;

        // 0xF806
        public uint? afterCompressWeight;

        // 0x8007
        public uint? afterCompressHeight;

        public override void Write(ProtoTreeRoot root)
        {
            root.AddTree("0A", textDetections?.BuildTree());
            root.AddTree("12", language?.BuildTree());
            root.AddLeafString("1A", requestId);
            root.AddLeafString("AA06", ocrLanguageList);
            root.AddLeafString("B206", dstTranslateLanguageList);
            root.AddTree("00", languageList?.BuildTree());
            root.AddLeafVar("F806", afterCompressWeight);
            root.AddLeafVar("8007", afterCompressHeight);
        }
    }

    public class Polygon : OidbStruct
    {
        // 0x0A
        public Coordinate coordinates;

        public override void Write(ProtoTreeRoot root)
        {
            root.AddTree("0A", coordinates?.BuildTree());
        }
    }

    public class ReqBody : OidbStruct
    {
        // 0x08
        public uint? version;

        // 0x10
        public uint? client;

        // 0x18
        public uint? entrance;

        // 0x52
        public OCRReqBody ocrReqBody;

        public override void Write(ProtoTreeRoot root)
        {
            root.AddLeafVar("08", version);
            root.AddLeafVar("10", client);
            root.AddLeafVar("18", entrance);
            root.AddTree("52", ocrReqBody?.BuildTree());
        }
    }

    public class RspBody : OidbStruct
    {
        // 0x08
        public uint? retCode;

        // 0x12
        public string errMsg;

        // 0x1A
        public string wording;

        // 0x52
        public OCRRspBody ocrRspBody;

        public override void Write(ProtoTreeRoot root)
        {
            root.AddLeafVar("08", retCode);
            root.AddLeafString("12", errMsg);
            root.AddLeafString("1A", wording);
            root.AddTree("52", ocrRspBody?.BuildTree());
        }
    }

    public class TextDetection : OidbStruct
    {
        // 0x0A
        public string detectedText;

        // 0x10
        public uint? confidence;

        // 0x1A
        public Polygon polygon;

        // 0x22
        public string advancedInfo;

        public override void Write(ProtoTreeRoot root)
        {
            root.AddLeafString("0A", detectedText);
            root.AddLeafVar("10", confidence);
            root.AddTree("1A", polygon?.BuildTree());
            root.AddLeafString("22", advancedInfo);
        }
    }
}