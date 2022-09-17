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

      var tmp416 = new Dictionary<string, string>(source.Count);
      foreach (var pair in source)
        tmp416.Add((pair.Key != null) ? pair.Key : null, (pair.Value != null) ? pair.Value : null);
      return tmp416;
    }


    public static bool Equals(this List<global::CUGOJ.RPC.Gen.Common.ContestProblemStruct> instance, object that)
    {
      if (!(that is List<global::CUGOJ.RPC.Gen.Common.ContestProblemStruct> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this List<global::CUGOJ.RPC.Gen.Common.ContestProblemStruct> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static List<global::CUGOJ.RPC.Gen.Common.ContestProblemStruct> DeepCopy(this List<global::CUGOJ.RPC.Gen.Common.ContestProblemStruct> source)
    {
      if (source == null)
        return null;

      var tmp417 = new List<global::CUGOJ.RPC.Gen.Common.ContestProblemStruct>(source.Count);
      foreach (var elem in source)
        tmp417.Add((elem != null) ? elem.DeepCopy() : null);
      return tmp417;
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

      var tmp418 = new List<global::CUGOJ.RPC.Gen.Common.ContestStruct>(source.Count);
      foreach (var elem in source)
        tmp418.Add((elem != null) ? elem.DeepCopy() : null);
      return tmp418;
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

      var tmp419 = new List<global::CUGOJ.RPC.Gen.Common.ProblemStruct>(source.Count);
      foreach (var elem in source)
        tmp419.Add((elem != null) ? elem.DeepCopy() : null);
      return tmp419;
    }


    public static bool Equals(this List<global::CUGOJ.RPC.Gen.Common.RegisterStruct> instance, object that)
    {
      if (!(that is List<global::CUGOJ.RPC.Gen.Common.RegisterStruct> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this List<global::CUGOJ.RPC.Gen.Common.RegisterStruct> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static List<global::CUGOJ.RPC.Gen.Common.RegisterStruct> DeepCopy(this List<global::CUGOJ.RPC.Gen.Common.RegisterStruct> source)
    {
      if (source == null)
        return null;

      var tmp420 = new List<global::CUGOJ.RPC.Gen.Common.RegisterStruct>(source.Count);
      foreach (var elem in source)
        tmp420.Add((elem != null) ? elem.DeepCopy() : null);
      return tmp420;
    }


    public static bool Equals(this List<global::CUGOJ.RPC.Gen.Common.SubmissionStruct> instance, object that)
    {
      if (!(that is List<global::CUGOJ.RPC.Gen.Common.SubmissionStruct> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this List<global::CUGOJ.RPC.Gen.Common.SubmissionStruct> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static List<global::CUGOJ.RPC.Gen.Common.SubmissionStruct> DeepCopy(this List<global::CUGOJ.RPC.Gen.Common.SubmissionStruct> source)
    {
      if (source == null)
        return null;

      var tmp421 = new List<global::CUGOJ.RPC.Gen.Common.SubmissionStruct>(source.Count);
      foreach (var elem in source)
        tmp421.Add((elem != null) ? elem.DeepCopy() : null);
      return tmp421;
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

      var tmp422 = new List<global::CUGOJ.RPC.Gen.Common.UserStruct>(source.Count);
      foreach (var elem in source)
        tmp422.Add((elem != null) ? elem.DeepCopy() : null);
      return tmp422;
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

      var tmp423 = new List<long>(source.Count);
      foreach (var elem in source)
        tmp423.Add(elem);
      return tmp423;
    }


    public static bool Equals(this List<string> instance, object that)
    {
      if (!(that is List<string> other)) return false;
      if (ReferenceEquals(instance, other)) return true;

      return TCollections.Equals(instance, other);
    }


    public static int GetHashCode(this List<string> instance)
    {
      return TCollections.GetHashCode(instance);
    }


    public static List<string> DeepCopy(this List<string> source)
    {
      if (source == null)
        return null;

      var tmp424 = new List<string>(source.Count);
      foreach (var elem in source)
        tmp424.Add((elem != null) ? elem : null);
      return tmp424;
    }


  }
}
