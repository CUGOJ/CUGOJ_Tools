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

namespace CUGOJ.RPC.Gen.Services.Base
{
  public static class baseExtensions
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

      var tmp312 = new Dictionary<string, string>(source.Count);
      foreach (var pair in source)
        tmp312.Add((pair.Key != null) ? pair.Key : null, (pair.Value != null) ? pair.Value : null);
      return tmp312;
    }


    public static bool Equals(this List<global::CUGOJ.RPC.Gen.Common.ContestStruct> instance, object that)
    {
      if (!(that is List<global::CUGOJ.RPC.Gen.Common.ContestStruct> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this List<global::CUGOJ.RPC.Gen.Common.ContestStruct> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static List<global::CUGOJ.RPC.Gen.Common.ContestStruct> DeepCopy(this List<global::CUGOJ.RPC.Gen.Common.ContestStruct> source)
    {
      if (source == null)
        return null;

      var tmp313 = new List<global::CUGOJ.RPC.Gen.Common.ContestStruct>(source.Count);
      foreach (var elem in source)
        tmp313.Add((elem != null) ? elem.DeepCopy() : null);
      return tmp313;
    }


    public static bool Equals(this List<global::CUGOJ.RPC.Gen.Common.ProblemStruct> instance, object that)
    {
      if (!(that is List<global::CUGOJ.RPC.Gen.Common.ProblemStruct> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this List<global::CUGOJ.RPC.Gen.Common.ProblemStruct> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static List<global::CUGOJ.RPC.Gen.Common.ProblemStruct> DeepCopy(this List<global::CUGOJ.RPC.Gen.Common.ProblemStruct> source)
    {
      if (source == null)
        return null;

      var tmp314 = new List<global::CUGOJ.RPC.Gen.Common.ProblemStruct>(source.Count);
      foreach (var elem in source)
        tmp314.Add((elem != null) ? elem.DeepCopy() : null);
      return tmp314;
    }


    public static bool Equals(this List<global::CUGOJ.RPC.Gen.Common.UserStruct> instance, object that)
    {
      if (!(that is List<global::CUGOJ.RPC.Gen.Common.UserStruct> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this List<global::CUGOJ.RPC.Gen.Common.UserStruct> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static List<global::CUGOJ.RPC.Gen.Common.UserStruct> DeepCopy(this List<global::CUGOJ.RPC.Gen.Common.UserStruct> source)
    {
      if (source == null)
        return null;

      var tmp315 = new List<global::CUGOJ.RPC.Gen.Common.UserStruct>(source.Count);
      foreach (var elem in source)
        tmp315.Add((elem != null) ? elem.DeepCopy() : null);
      return tmp315;
    }


    public static bool Equals(this List<long> instance, object that)
    {
      if (!(that is List<long> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this List<long> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static List<long> DeepCopy(this List<long> source)
    {
      if (source == null)
        return null;

      var tmp316 = new List<long>(source.Count);
      foreach (var elem in source)
        tmp316.Add(elem);
      return tmp316;
    }


  }
}