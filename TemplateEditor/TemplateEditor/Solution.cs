//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Solution.proto
// Note: requires additional types generated from: config_common.proto
namespace Solution
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ConfigPath")]
  public partial class ConfigPath : global::ProtoBuf.IExtensible
  {
    public ConfigPath() {}
    
    private readonly global::System.Collections.Generic.List<int> _version = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(1, Name=@"version", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public global::System.Collections.Generic.List<int> version
    {
      get { return _version; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}