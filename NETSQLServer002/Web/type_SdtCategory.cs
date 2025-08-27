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
   [XmlRoot(ElementName = "Category" )]
   [XmlType(TypeName =  "Category" , Namespace = "ObligatorioShop" )]
   [Serializable]
   public class SdtCategory : GxSilentTrnSdt
   {
      public SdtCategory( )
      {
      }

      public SdtCategory( IGxContext context )
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

      public void Load( short AV4CategoryId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV4CategoryId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CategoryId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Category");
         metadata.Set("BT", "Category");
         metadata.Set("PK", "[ \"CategoryId\" ]");
         metadata.Set("PKAssigned", "[ \"CategoryId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Categoryid_Z");
         state.Add("gxTpr_Categoryname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCategory sdt;
         sdt = (SdtCategory)(source);
         gxTv_SdtCategory_Categoryid = sdt.gxTv_SdtCategory_Categoryid ;
         gxTv_SdtCategory_Categoryname = sdt.gxTv_SdtCategory_Categoryname ;
         gxTv_SdtCategory_Mode = sdt.gxTv_SdtCategory_Mode ;
         gxTv_SdtCategory_Initialized = sdt.gxTv_SdtCategory_Initialized ;
         gxTv_SdtCategory_Categoryid_Z = sdt.gxTv_SdtCategory_Categoryid_Z ;
         gxTv_SdtCategory_Categoryname_Z = sdt.gxTv_SdtCategory_Categoryname_Z ;
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
         AddObjectProperty("CategoryId", gxTv_SdtCategory_Categoryid, false, includeNonInitialized);
         AddObjectProperty("CategoryName", gxTv_SdtCategory_Categoryname, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCategory_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCategory_Initialized, false, includeNonInitialized);
            AddObjectProperty("CategoryId_Z", gxTv_SdtCategory_Categoryid_Z, false, includeNonInitialized);
            AddObjectProperty("CategoryName_Z", gxTv_SdtCategory_Categoryname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCategory sdt )
      {
         if ( sdt.IsDirty("CategoryId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCategory_Categoryid = sdt.gxTv_SdtCategory_Categoryid ;
         }
         if ( sdt.IsDirty("CategoryName") )
         {
            sdtIsNull = 0;
            gxTv_SdtCategory_Categoryname = sdt.gxTv_SdtCategory_Categoryname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CategoryId" )]
      [  XmlElement( ElementName = "CategoryId"   )]
      public short gxTpr_Categoryid
      {
         get {
            return gxTv_SdtCategory_Categoryid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCategory_Categoryid != value )
            {
               gxTv_SdtCategory_Mode = "INS";
               this.gxTv_SdtCategory_Categoryid_Z_SetNull( );
               this.gxTv_SdtCategory_Categoryname_Z_SetNull( );
            }
            gxTv_SdtCategory_Categoryid = value;
            SetDirty("Categoryid");
         }

      }

      [  SoapElement( ElementName = "CategoryName" )]
      [  XmlElement( ElementName = "CategoryName"   )]
      public string gxTpr_Categoryname
      {
         get {
            return gxTv_SdtCategory_Categoryname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategory_Categoryname = value;
            SetDirty("Categoryname");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCategory_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategory_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCategory_Mode_SetNull( )
      {
         gxTv_SdtCategory_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCategory_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCategory_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategory_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCategory_Initialized_SetNull( )
      {
         gxTv_SdtCategory_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCategory_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryId_Z" )]
      [  XmlElement( ElementName = "CategoryId_Z"   )]
      public short gxTpr_Categoryid_Z
      {
         get {
            return gxTv_SdtCategory_Categoryid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategory_Categoryid_Z = value;
            SetDirty("Categoryid_Z");
         }

      }

      public void gxTv_SdtCategory_Categoryid_Z_SetNull( )
      {
         gxTv_SdtCategory_Categoryid_Z = 0;
         SetDirty("Categoryid_Z");
         return  ;
      }

      public bool gxTv_SdtCategory_Categoryid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoryName_Z" )]
      [  XmlElement( ElementName = "CategoryName_Z"   )]
      public string gxTpr_Categoryname_Z
      {
         get {
            return gxTv_SdtCategory_Categoryname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategory_Categoryname_Z = value;
            SetDirty("Categoryname_Z");
         }

      }

      public void gxTv_SdtCategory_Categoryname_Z_SetNull( )
      {
         gxTv_SdtCategory_Categoryname_Z = "";
         SetDirty("Categoryname_Z");
         return  ;
      }

      public bool gxTv_SdtCategory_Categoryname_Z_IsNull( )
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
         gxTv_SdtCategory_Categoryname = "";
         gxTv_SdtCategory_Mode = "";
         gxTv_SdtCategory_Categoryname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "category", "GeneXus.Programs.category_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtCategory_Categoryid ;
      private short sdtIsNull ;
      private short gxTv_SdtCategory_Initialized ;
      private short gxTv_SdtCategory_Categoryid_Z ;
      private string gxTv_SdtCategory_Mode ;
      private string gxTv_SdtCategory_Categoryname ;
      private string gxTv_SdtCategory_Categoryname_Z ;
   }

   [DataContract(Name = @"Category", Namespace = "ObligatorioShop")]
   [GxJsonSerialization("default")]
   public class SdtCategory_RESTInterface : GxGenericCollectionItem<SdtCategory>
   {
      public SdtCategory_RESTInterface( ) : base()
      {
      }

      public SdtCategory_RESTInterface( SdtCategory psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CategoryId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Categoryid
      {
         get {
            return sdt.gxTpr_Categoryid ;
         }

         set {
            sdt.gxTpr_Categoryid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CategoryName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Categoryname
      {
         get {
            return sdt.gxTpr_Categoryname ;
         }

         set {
            sdt.gxTpr_Categoryname = value;
         }

      }

      public SdtCategory sdt
      {
         get {
            return (SdtCategory)Sdt ;
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
            sdt = new SdtCategory() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 2 )]
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

   [DataContract(Name = @"Category", Namespace = "ObligatorioShop")]
   [GxJsonSerialization("default")]
   public class SdtCategory_RESTLInterface : GxGenericCollectionItem<SdtCategory>
   {
      public SdtCategory_RESTLInterface( ) : base()
      {
      }

      public SdtCategory_RESTLInterface( SdtCategory psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CategoryName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Categoryname
      {
         get {
            return sdt.gxTpr_Categoryname ;
         }

         set {
            sdt.gxTpr_Categoryname = value;
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

      public SdtCategory sdt
      {
         get {
            return (SdtCategory)Sdt ;
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
            sdt = new SdtCategory() ;
         }
      }

   }

}
