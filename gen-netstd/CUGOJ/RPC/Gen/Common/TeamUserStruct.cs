/**
 * <auto-generated>
 * Autogenerated by Thrift Compiler (0.16.0)
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 * </auto-generated>
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;

using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#nullable disable                // suppress C# 8.0 nullable contexts (we still support earlier versions)
#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

namespace CUGOJ.RPC.Gen.Common
{

  public partial class TeamUserStruct : TBase
  {
    private long _ID;
    private global::CUGOJ.RPC.Gen.Common.TeamStruct _Team;
    private global::CUGOJ.RPC.Gen.Common.UserStruct _User;
    private global::CUGOJ.RPC.Gen.Common.TeamUserTypeEnum _Type;
    private long _CreateTime;
    private long _UpdateTime;

    public long ID
    {
      get
      {
        return _ID;
      }
      set
      {
        __isset.ID = true;
        this._ID = value;
      }
    }

    public global::CUGOJ.RPC.Gen.Common.TeamStruct Team
    {
      get
      {
        return _Team;
      }
      set
      {
        __isset.Team = true;
        this._Team = value;
      }
    }

    public global::CUGOJ.RPC.Gen.Common.UserStruct User
    {
      get
      {
        return _User;
      }
      set
      {
        __isset.User = true;
        this._User = value;
      }
    }

    /// <summary>
    /// 
    /// <seealso cref="global::CUGOJ.RPC.Gen.Common.TeamUserTypeEnum"/>
    /// </summary>
    public global::CUGOJ.RPC.Gen.Common.TeamUserTypeEnum Type
    {
      get
      {
        return _Type;
      }
      set
      {
        __isset.Type = true;
        this._Type = value;
      }
    }

    public long CreateTime
    {
      get
      {
        return _CreateTime;
      }
      set
      {
        __isset.CreateTime = true;
        this._CreateTime = value;
      }
    }

    public long UpdateTime
    {
      get
      {
        return _UpdateTime;
      }
      set
      {
        __isset.UpdateTime = true;
        this._UpdateTime = value;
      }
    }


    public Isset __isset;
    public struct Isset
    {
      public bool ID;
      public bool Team;
      public bool User;
      public bool Type;
      public bool CreateTime;
      public bool UpdateTime;
    }

    public TeamUserStruct()
    {
    }

    public TeamUserStruct DeepCopy()
    {
      var tmp34 = new TeamUserStruct();
      if(__isset.ID)
      {
        tmp34.ID = this.ID;
      }
      tmp34.__isset.ID = this.__isset.ID;
      if((Team != null) && __isset.Team)
      {
        tmp34.Team = (global::CUGOJ.RPC.Gen.Common.TeamStruct)this.Team.DeepCopy();
      }
      tmp34.__isset.Team = this.__isset.Team;
      if((User != null) && __isset.User)
      {
        tmp34.User = (global::CUGOJ.RPC.Gen.Common.UserStruct)this.User.DeepCopy();
      }
      tmp34.__isset.User = this.__isset.User;
      if(__isset.Type)
      {
        tmp34.Type = this.Type;
      }
      tmp34.__isset.Type = this.__isset.Type;
      if(__isset.CreateTime)
      {
        tmp34.CreateTime = this.CreateTime;
      }
      tmp34.__isset.CreateTime = this.__isset.CreateTime;
      if(__isset.UpdateTime)
      {
        tmp34.UpdateTime = this.UpdateTime;
      }
      tmp34.__isset.UpdateTime = this.__isset.UpdateTime;
      return tmp34;
    }

    public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        await iprot.ReadStructBeginAsync(cancellationToken);
        while (true)
        {
          field = await iprot.ReadFieldBeginAsync(cancellationToken);
          if (field.Type == TType.Stop)
          {
            break;
          }

          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I64)
              {
                ID = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 2:
              if (field.Type == TType.Struct)
              {
                Team = new global::CUGOJ.RPC.Gen.Common.TeamStruct();
                await Team.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 3:
              if (field.Type == TType.Struct)
              {
                User = new global::CUGOJ.RPC.Gen.Common.UserStruct();
                await User.ReadAsync(iprot, cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 4:
              if (field.Type == TType.I32)
              {
                Type = (global::CUGOJ.RPC.Gen.Common.TeamUserTypeEnum)await iprot.ReadI32Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 5:
              if (field.Type == TType.I64)
              {
                CreateTime = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            case 6:
              if (field.Type == TType.I64)
              {
                UpdateTime = await iprot.ReadI64Async(cancellationToken);
              }
              else
              {
                await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              }
              break;
            default: 
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
              break;
          }

          await iprot.ReadFieldEndAsync(cancellationToken);
        }

        await iprot.ReadStructEndAsync(cancellationToken);
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
    {
      oprot.IncrementRecursionDepth();
      try
      {
        var tmp35 = new TStruct("TeamUserStruct");
        await oprot.WriteStructBeginAsync(tmp35, cancellationToken);
        var tmp36 = new TField();
        if(__isset.ID)
        {
          tmp36.Name = "ID";
          tmp36.Type = TType.I64;
          tmp36.ID = 1;
          await oprot.WriteFieldBeginAsync(tmp36, cancellationToken);
          await oprot.WriteI64Async(ID, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((Team != null) && __isset.Team)
        {
          tmp36.Name = "Team";
          tmp36.Type = TType.Struct;
          tmp36.ID = 2;
          await oprot.WriteFieldBeginAsync(tmp36, cancellationToken);
          await Team.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if((User != null) && __isset.User)
        {
          tmp36.Name = "User";
          tmp36.Type = TType.Struct;
          tmp36.ID = 3;
          await oprot.WriteFieldBeginAsync(tmp36, cancellationToken);
          await User.WriteAsync(oprot, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.Type)
        {
          tmp36.Name = "Type";
          tmp36.Type = TType.I32;
          tmp36.ID = 4;
          await oprot.WriteFieldBeginAsync(tmp36, cancellationToken);
          await oprot.WriteI32Async((int)Type, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.CreateTime)
        {
          tmp36.Name = "CreateTime";
          tmp36.Type = TType.I64;
          tmp36.ID = 5;
          await oprot.WriteFieldBeginAsync(tmp36, cancellationToken);
          await oprot.WriteI64Async(CreateTime, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        if(__isset.UpdateTime)
        {
          tmp36.Name = "UpdateTime";
          tmp36.Type = TType.I64;
          tmp36.ID = 6;
          await oprot.WriteFieldBeginAsync(tmp36, cancellationToken);
          await oprot.WriteI64Async(UpdateTime, cancellationToken);
          await oprot.WriteFieldEndAsync(cancellationToken);
        }
        await oprot.WriteFieldStopAsync(cancellationToken);
        await oprot.WriteStructEndAsync(cancellationToken);
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override bool Equals(object that)
    {
      if (!(that is TeamUserStruct other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return ((__isset.ID == other.__isset.ID) && ((!__isset.ID) || (global::System.Object.Equals(ID, other.ID))))
        && ((__isset.Team == other.__isset.Team) && ((!__isset.Team) || (global::System.Object.Equals(Team, other.Team))))
        && ((__isset.User == other.__isset.User) && ((!__isset.User) || (global::System.Object.Equals(User, other.User))))
        && ((__isset.Type == other.__isset.Type) && ((!__isset.Type) || (global::System.Object.Equals(Type, other.Type))))
        && ((__isset.CreateTime == other.__isset.CreateTime) && ((!__isset.CreateTime) || (global::System.Object.Equals(CreateTime, other.CreateTime))))
        && ((__isset.UpdateTime == other.__isset.UpdateTime) && ((!__isset.UpdateTime) || (global::System.Object.Equals(UpdateTime, other.UpdateTime))));
    }

    public override int GetHashCode() {
      int hashcode = 157;
      unchecked {
        if(__isset.ID)
        {
          hashcode = (hashcode * 397) + ID.GetHashCode();
        }
        if((Team != null) && __isset.Team)
        {
          hashcode = (hashcode * 397) + Team.GetHashCode();
        }
        if((User != null) && __isset.User)
        {
          hashcode = (hashcode * 397) + User.GetHashCode();
        }
        if(__isset.Type)
        {
          hashcode = (hashcode * 397) + Type.GetHashCode();
        }
        if(__isset.CreateTime)
        {
          hashcode = (hashcode * 397) + CreateTime.GetHashCode();
        }
        if(__isset.UpdateTime)
        {
          hashcode = (hashcode * 397) + UpdateTime.GetHashCode();
        }
      }
      return hashcode;
    }

    public override string ToString()
    {
      var tmp37 = new StringBuilder("TeamUserStruct(");
      int tmp38 = 0;
      if(__isset.ID)
      {
        if(0 < tmp38++) { tmp37.Append(", "); }
        tmp37.Append("ID: ");
        ID.ToString(tmp37);
      }
      if((Team != null) && __isset.Team)
      {
        if(0 < tmp38++) { tmp37.Append(", "); }
        tmp37.Append("Team: ");
        Team.ToString(tmp37);
      }
      if((User != null) && __isset.User)
      {
        if(0 < tmp38++) { tmp37.Append(", "); }
        tmp37.Append("User: ");
        User.ToString(tmp37);
      }
      if(__isset.Type)
      {
        if(0 < tmp38++) { tmp37.Append(", "); }
        tmp37.Append("Type: ");
        Type.ToString(tmp37);
      }
      if(__isset.CreateTime)
      {
        if(0 < tmp38++) { tmp37.Append(", "); }
        tmp37.Append("CreateTime: ");
        CreateTime.ToString(tmp37);
      }
      if(__isset.UpdateTime)
      {
        if(0 < tmp38++) { tmp37.Append(", "); }
        tmp37.Append("UpdateTime: ");
        UpdateTime.ToString(tmp37);
      }
      tmp37.Append(')');
      return tmp37.ToString();
    }
  }

}
