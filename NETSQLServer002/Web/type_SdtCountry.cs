using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Country" )]
   [XmlType(TypeName =  "Country" , Namespace = "ObligatorioShop" )]
   [Serializable]
   public class SdtCountry : GxSilentTrnSdt
   {
      public SdtCountry( )
      {
      }

      public SdtCountry( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV1CountryId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV1CountryId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CountryId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Country");
         metadata.Set("BT", "Country");
         metadata.Set("PK", "[ \"CountryId\" ]");
         metadata.Set("PKAssigned", "[ \"CountryId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Countryflag_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Countryid_Z");
         state.Add("gxTpr_Countryname_Z");
         state.Add("gxTpr_Countryflag_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCountry sdt;
         sdt = (SdtCountry)(source);
         gxTv_SdtCountry_Countryid = sdt.gxTv_SdtCountry_Countryid ;
         gxTv_SdtCountry_Countryname = sdt.gxTv_SdtCountry_Countryname ;
         gxTv_SdtCountry_Countryflag = sdt.gxTv_SdtCountry_Countryflag ;
         gxTv_SdtCountry_Countryflag_gxi = sdt.gxTv_SdtCountry_Countryflag_gxi ;
         gxTv_SdtCountry_Mode = sdt.gxTv_SdtCountry_Mode ;
         gxTv_SdtCountry_Initialized = sdt.gxTv_SdtCountry_Initialized ;
         gxTv_SdtCountry_Countryid_Z = sdt.gxTv_SdtCountry_Countryid_Z ;
         gxTv_SdtCountry_Countryname_Z = sdt.gxTv_SdtCountry_Countryname_Z ;
         gxTv_SdtCountry_Countryflag_gxi_Z = sdt.gxTv_SdtCountry_Countryflag_gxi_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("CountryId", gxTv_SdtCountry_Countryid, false, includeNonInitialized);
         AddObjectProperty("CountryName", gxTv_SdtCountry_Countryname, false, includeNonInitialized);
         AddObjectProperty("CountryFlag", gxTv_SdtCountry_Countryflag, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("CountryFlag_GXI", gxTv_SdtCountry_Countryflag_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtCountry_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCountry_Initialized, false, includeNonInitialized);
            AddObjectProperty("CountryId_Z", gxTv_SdtCountry_Countryid_Z, false, includeNonInitialized);
            AddObjectProperty("CountryName_Z", gxTv_SdtCountry_Countryname_Z, false, includeNonInitialized);
            AddObjectProperty("CountryFlag_GXI_Z", gxTv_SdtCountry_Countryflag_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCountry sdt )
      {
         if ( sdt.IsDirty("CountryId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCountry_Countryid = sdt.gxTv_SdtCountry_Countryid ;
         }
         if ( sdt.IsDirty("CountryName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCountry_Countryname = sdt.gxTv_SdtCountry_Countryname ;
         }
         if ( sdt.IsDirty("CountryFlag") )
         {
            sdtIsNull = 0;
            gxTv_SdtCountry_Countryflag = sdt.gxTv_SdtCountry_Countryflag ;
         }
         if ( sdt.IsDirty("CountryFlag") )
         {
            sdtIsNull = 0;
            gxTv_SdtCountry_Countryflag_gxi = sdt.gxTv_SdtCountry_Countryflag_gxi ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CountryId" )]
      [  XmlElement( ElementName = "CountryId"   )]
      public short gxTpr_Countryid
      {
         get {
            return gxTv_SdtCountry_Countryid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCountry_Countryid != value )
            {
               gxTv_SdtCountry_Mode = "INS";
               this.gxTv_SdtCountry_Countryid_Z_SetNull( );
               this.gxTv_SdtCountry_Countryname_Z_SetNull( );
               this.gxTv_SdtCountry_Countryflag_gxi_Z_SetNull( );
            }
            gxTv_SdtCountry_Countryid = value;
            SetDirty("Countryid");
         }

      }

      [  SoapElement( ElementName = "CountryName" )]
      [  XmlElement( ElementName = "CountryName"   )]
      public string gxTpr_Countryname
      {
         get {
            return gxTv_SdtCountry_Countryname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCountry_Countryname = value;
            SetDirty("Countryname");
         }

      }

      [  SoapElement( ElementName = "CountryFlag" )]
      [  XmlElement( ElementName = "CountryFlag"   )]
      [GxUpload()]
      public string gxTpr_Countryflag
      {
         get {
            return gxTv_SdtCountry_Countryflag ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCountry_Countryflag = value;
            SetDirty("Countryflag");
         }

      }

      [  SoapElement( ElementName = "CountryFlag_GXI" )]
      [  XmlElement( ElementName = "CountryFlag_GXI"   )]
      public string gxTpr_Countryflag_gxi
      {
         get {
            return gxTv_SdtCountry_Countryflag_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCountry_Countryflag_gxi = value;
            SetDirty("Countryflag_gxi");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCountry_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCountry_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCountry_Mode_SetNull( )
      {
         gxTv_SdtCountry_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCountry_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCountry_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCountry_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCountry_Initialized_SetNull( )
      {
         gxTv_SdtCountry_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCountry_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryId_Z" )]
      [  XmlElement( ElementName = "CountryId_Z"   )]
      public short gxTpr_Countryid_Z
      {
         get {
            return gxTv_SdtCountry_Countryid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCountry_Countryid_Z = value;
            SetDirty("Countryid_Z");
         }

      }

      public void gxTv_SdtCountry_Countryid_Z_SetNull( )
      {
         gxTv_SdtCountry_Countryid_Z = 0;
         SetDirty("Countryid_Z");
         return  ;
      }

      public bool gxTv_SdtCountry_Countryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryName_Z" )]
      [  XmlElement( ElementName = "CountryName_Z"   )]
      public string gxTpr_Countryname_Z
      {
         get {
            return gxTv_SdtCountry_Countryname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCountry_Countryname_Z = value;
            SetDirty("Countryname_Z");
         }

      }

      public void gxTv_SdtCountry_Countryname_Z_SetNull( )
      {
         gxTv_SdtCountry_Countryname_Z = "";
         SetDirty("Countryname_Z");
         return  ;
      }

      public bool gxTv_SdtCountry_Countryname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CountryFlag_GXI_Z" )]
      [  XmlElement( ElementName = "CountryFlag_GXI_Z"   )]
      public string gxTpr_Countryflag_gxi_Z
      {
         get {
            return gxTv_SdtCountry_Countryflag_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCountry_Countryflag_gxi_Z = value;
            SetDirty("Countryflag_gxi_Z");
         }

      }

      public void gxTv_SdtCountry_Countryflag_gxi_Z_SetNull( )
      {
         gxTv_SdtCountry_Countryflag_gxi_Z = "";
         SetDirty("Countryflag_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtCountry_Countryflag_gxi_Z_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtCountry_Countryname = "";
         gxTv_SdtCountry_Countryflag = "";
         gxTv_SdtCountry_Countryflag_gxi = "";
         gxTv_SdtCountry_Mode = "";
         gxTv_SdtCountry_Countryname_Z = "";
         gxTv_SdtCountry_Countryflag_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "country", "GeneXus.Programs.country_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtCountry_Countryid ;
      private short sdtIsNull ;
      private short gxTv_SdtCountry_Initialized ;
      private short gxTv_SdtCountry_Countryid_Z ;
      private string gxTv_SdtCountry_Mode ;
      private string gxTv_SdtCountry_Countryname ;
      private string gxTv_SdtCountry_Countryflag_gxi ;
      private string gxTv_SdtCountry_Countryname_Z ;
      private string gxTv_SdtCountry_Countryflag_gxi_Z ;
      private string gxTv_SdtCountry_Countryflag ;
   }

   [DataContract(Name = @"Country", Namespace = "ObligatorioShop")]
   [GxJsonSerialization("default")]
   public class SdtCountry_RESTInterface : GxGenericCollectionItem<SdtCountry>
   {
      public SdtCountry_RESTInterface( ) : base()
      {
      }

      public SdtCountry_RESTInterface( SdtCountry psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CountryId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Countryid
      {
         get {
            return sdt.gxTpr_Countryid ;
         }

         set {
            sdt.gxTpr_Countryid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CountryName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Countryname
      {
         get {
            return sdt.gxTpr_Countryname ;
         }

         set {
            sdt.gxTpr_Countryname = value;
         }

      }

      [DataMember( Name = "CountryFlag" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Countryflag
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Countryflag)) ? PathUtil.RelativeURL( sdt.gxTpr_Countryflag) : StringUtil.RTrim( sdt.gxTpr_Countryflag_gxi)) ;
         }

         set {
            sdt.gxTpr_Countryflag = value;
         }

      }

      public SdtCountry sdt
      {
         get {
            return (SdtCountry)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtCountry() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Country", Namespace = "ObligatorioShop")]
   [GxJsonSerialization("default")]
   public class SdtCountry_RESTLInterface : GxGenericCollectionItem<SdtCountry>
   {
      public SdtCountry_RESTLInterface( ) : base()
      {
      }

      public SdtCountry_RESTLInterface( SdtCountry psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CountryName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Countryname
      {
         get {
            return sdt.gxTpr_Countryname ;
         }

         set {
            sdt.gxTpr_Countryname = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtCountry sdt
      {
         get {
            return (SdtCountry)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtCountry() ;
         }
      }

   }

}
