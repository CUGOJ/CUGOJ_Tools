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


#nullable disable                // suppress C# 8.0 nullable contexts (we still support earlier versions)
#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions

namespace CUGOJ.RPC.Gen.Services.Core
{
  public static class coreExtensions
  {
    public static bool Equals(this Dictionary<string, string> instance, object that)
    {
      if (!(that is Dictionary<string, string> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this Dictionary<string, string> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static Dictionary<string, string> DeepCopy(this Dictionary<string, string> source)
    {
      if (source == null)
        return null;

      var tmp81 = new Dictionary<string, string>(source.Count);
      foreach (var pair in source)
        tmp81.Add((pair.Key != null) ? pair.Key : null, (pair.Value != null) ? pair.Value : null);
      return tmp81;
    }


    public static bool Equals(this List<global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo> instance, object that)
    {
      if (!(that is List<global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this List<global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static List<global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo> DeepCopy(this List<global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo> source)
    {
      if (source == null)
        return null;

      var tmp82 = new List<global::CUGOJ.RPC.Gen.Base.ServiceBaseInfo>(source.Count);
      foreach (var elem in source)
        tmp82.Add((elem != null) ? elem.DeepCopy() : null);
      return tmp82;
    }


  }
}
