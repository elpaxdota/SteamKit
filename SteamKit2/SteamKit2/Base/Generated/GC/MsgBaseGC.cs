//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#pragma warning disable 1591

// Option: light framework (CF/Silverlight) enabled
    
// Generated from: gc.proto
namespace SteamKit2.GC.Internal
{
  [global::ProtoBuf.ProtoContract(Name=@"CMsgProtoBufHeader")]
  public partial class CMsgProtoBufHeader : global::ProtoBuf.IExtensible
  {
    public CMsgProtoBufHeader() {}
    

    private ulong _client_steam_id = default(ulong);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"client_steam_id", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong client_steam_id
    {
      get { return _client_steam_id; }
      set { _client_steam_id = value; }
    }

    private int _client_session_id = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"client_session_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int client_session_id
    {
      get { return _client_session_id; }
      set { _client_session_id = value; }
    }

    private uint _source_app_id = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"source_app_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint source_app_id
    {
      get { return _source_app_id; }
      set { _source_app_id = value; }
    }

    private ulong _job_id_source = (ulong)18446744073709551615;
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"job_id_source", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(@"18446744073709551615")]
    public ulong job_id_source
    {
      get { return _job_id_source; }
      set { _job_id_source = value; }
    }

    private ulong _job_id_target = (ulong)18446744073709551615;
    [global::ProtoBuf.ProtoMember(11, IsRequired = false, Name=@"job_id_target", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(@"18446744073709551615")]
    public ulong job_id_target
    {
      get { return _job_id_target; }
      set { _job_id_target = value; }
    }

    private string _target_job_name = "";
    [global::ProtoBuf.ProtoMember(12, IsRequired = false, Name=@"target_job_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string target_job_name
    {
      get { return _target_job_name; }
      set { _target_job_name = value; }
    }

    private int _eresult = (int)2;
    [global::ProtoBuf.ProtoMember(13, IsRequired = false, Name=@"eresult", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)2)]
    public int eresult
    {
      get { return _eresult; }
      set { _eresult = value; }
    }

    private string _error_message = "";
    [global::ProtoBuf.ProtoMember(14, IsRequired = false, Name=@"error_message", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string error_message
    {
      get { return _error_message; }
      set { _error_message = value; }
    }

    private GCProtoBufMsgSrc _gc_msg_src = GCProtoBufMsgSrc.GCProtoBufMsgSrc_Unspecified;
    [global::ProtoBuf.ProtoMember(200, IsRequired = false, Name=@"gc_msg_src", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(GCProtoBufMsgSrc.GCProtoBufMsgSrc_Unspecified)]
    public GCProtoBufMsgSrc gc_msg_src
    {
      get { return _gc_msg_src; }
      set { _gc_msg_src = value; }
    }

    private uint _gc_dir_index_source = default(uint);
    [global::ProtoBuf.ProtoMember(201, IsRequired = false, Name=@"gc_dir_index_source", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint gc_dir_index_source
    {
      get { return _gc_dir_index_source; }
      set { _gc_dir_index_source = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    [global::ProtoBuf.ProtoContract(Name=@"GCProtoBufMsgSrc", EnumPassthru=true)]
    public enum GCProtoBufMsgSrc
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"GCProtoBufMsgSrc_Unspecified", Value=0)]
      GCProtoBufMsgSrc_Unspecified = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GCProtoBufMsgSrc_FromSystem", Value=1)]
      GCProtoBufMsgSrc_FromSystem = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GCProtoBufMsgSrc_FromSteamID", Value=2)]
      GCProtoBufMsgSrc_FromSteamID = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GCProtoBufMsgSrc_FromGC", Value=3)]
      GCProtoBufMsgSrc_FromGC = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GCProtoBufMsgSrc_ReplySystem", Value=4)]
      GCProtoBufMsgSrc_ReplySystem = 4
    }
  
}
#pragma warning restore 1591