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
   [XmlRoot(ElementName = "PointCard" )]
   [XmlType(TypeName =  "PointCard" , Namespace = "ObligatorioShop" )]
   [Serializable]
   public class SdtPointCard : GxSilentTrnSdt
   {
      public SdtPointCard( )
      {
      }

      public SdtPointCard( IGxContext context )
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

      public void Load( short AV20PointCardId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV20PointCardId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PointCardId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "PointCard");
         metadata.Set("BT", "PointCard");
         metadata.Set("PK", "[ \"PointCardId\" ]");
         metadata.Set("PKAssigned", "[ \"PointCardId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CustomerId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Pointcardid_Z");
         state.Add("gxTpr_Customerid_Z");
         state.Add("gxTpr_Customername_Z");
         state.Add("gxTpr_Pointcardpoints_Z");
         state.Add("gxTpr_Pointcardvip_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPointCard sdt;
         sdt = (SdtPointCard)(source);
         gxTv_SdtPointCard_Pointcardid = sdt.gxTv_SdtPointCard_Pointcardid ;
         gxTv_SdtPointCard_Customerid = sdt.gxTv_SdtPointCard_Customerid ;
         gxTv_SdtPointCard_Customername = sdt.gxTv_SdtPointCard_Customername ;
         gxTv_SdtPointCard_Pointcardpoints = sdt.gxTv_SdtPointCard_Pointcardpoints ;
         gxTv_SdtPointCard_Pointcardvip = sdt.gxTv_SdtPointCard_Pointcardvip ;
         gxTv_SdtPointCard_Mode = sdt.gxTv_SdtPointCard_Mode ;
         gxTv_SdtPointCard_Initialized = sdt.gxTv_SdtPointCard_Initialized ;
         gxTv_SdtPointCard_Pointcardid_Z = sdt.gxTv_SdtPointCard_Pointcardid_Z ;
         gxTv_SdtPointCard_Customerid_Z = sdt.gxTv_SdtPointCard_Customerid_Z ;
         gxTv_SdtPointCard_Customername_Z = sdt.gxTv_SdtPointCard_Customername_Z ;
         gxTv_SdtPointCard_Pointcardpoints_Z = sdt.gxTv_SdtPointCard_Pointcardpoints_Z ;
         gxTv_SdtPointCard_Pointcardvip_Z = sdt.gxTv_SdtPointCard_Pointcardvip_Z ;
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
         AddObjectProperty("PointCardId", gxTv_SdtPointCard_Pointcardid, false, includeNonInitialized);
         AddObjectProperty("CustomerId", gxTv_SdtPointCard_Customerid, false, includeNonInitialized);
         AddObjectProperty("CustomerName", gxTv_SdtPointCard_Customername, false, includeNonInitialized);
         AddObjectProperty("PointCardPoints", gxTv_SdtPointCard_Pointcardpoints, false, includeNonInitialized);
         AddObjectProperty("PointCardVIP", gxTv_SdtPointCard_Pointcardvip, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPointCard_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPointCard_Initialized, false, includeNonInitialized);
            AddObjectProperty("PointCardId_Z", gxTv_SdtPointCard_Pointcardid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerId_Z", gxTv_SdtPointCard_Customerid_Z, false, includeNonInitialized);
            AddObjectProperty("CustomerName_Z", gxTv_SdtPointCard_Customername_Z, false, includeNonInitialized);
            AddObjectProperty("PointCardPoints_Z", gxTv_SdtPointCard_Pointcardpoints_Z, false, includeNonInitialized);
            AddObjectProperty("PointCardVIP_Z", gxTv_SdtPointCard_Pointcardvip_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPointCard sdt )
      {
         if ( sdt.IsDirty("PointCardId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Pointcardid = sdt.gxTv_SdtPointCard_Pointcardid ;
         }
         if ( sdt.IsDirty("CustomerId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Customerid = sdt.gxTv_SdtPointCard_Customerid ;
         }
         if ( sdt.IsDirty("CustomerName") )
         {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Customername = sdt.gxTv_SdtPointCard_Customername ;
         }
         if ( sdt.IsDirty("PointCardPoints") )
         {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Pointcardpoints = sdt.gxTv_SdtPointCard_Pointcardpoints ;
         }
         if ( sdt.IsDirty("PointCardVIP") )
         {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Pointcardvip = sdt.gxTv_SdtPointCard_Pointcardvip ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PointCardId" )]
      [  XmlElement( ElementName = "PointCardId"   )]
      public short gxTpr_Pointcardid
      {
         get {
            return gxTv_SdtPointCard_Pointcardid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPointCard_Pointcardid != value )
            {
               gxTv_SdtPointCard_Mode = "INS";
               this.gxTv_SdtPointCard_Pointcardid_Z_SetNull( );
               this.gxTv_SdtPointCard_Customerid_Z_SetNull( );
               this.gxTv_SdtPointCard_Customername_Z_SetNull( );
               this.gxTv_SdtPointCard_Pointcardpoints_Z_SetNull( );
               this.gxTv_SdtPointCard_Pointcardvip_Z_SetNull( );
            }
            gxTv_SdtPointCard_Pointcardid = value;
            SetDirty("Pointcardid");
         }

      }

      [  SoapElement( ElementName = "CustomerId" )]
      [  XmlElement( ElementName = "CustomerId"   )]
      public short gxTpr_Customerid
      {
         get {
            return gxTv_SdtPointCard_Customerid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Customerid = value;
            SetDirty("Customerid");
         }

      }

      [  SoapElement( ElementName = "CustomerName" )]
      [  XmlElement( ElementName = "CustomerName"   )]
      public string gxTpr_Customername
      {
         get {
            return gxTv_SdtPointCard_Customername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Customername = value;
            SetDirty("Customername");
         }

      }

      [  SoapElement( ElementName = "PointCardPoints" )]
      [  XmlElement( ElementName = "PointCardPoints"   )]
      public int gxTpr_Pointcardpoints
      {
         get {
            return gxTv_SdtPointCard_Pointcardpoints ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Pointcardpoints = value;
            SetDirty("Pointcardpoints");
         }

      }

      [  SoapElement( ElementName = "PointCardVIP" )]
      [  XmlElement( ElementName = "PointCardVIP"   )]
      public bool gxTpr_Pointcardvip
      {
         get {
            return gxTv_SdtPointCard_Pointcardvip ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Pointcardvip = value;
            SetDirty("Pointcardvip");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPointCard_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPointCard_Mode_SetNull( )
      {
         gxTv_SdtPointCard_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPointCard_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPointCard_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPointCard_Initialized_SetNull( )
      {
         gxTv_SdtPointCard_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPointCard_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PointCardId_Z" )]
      [  XmlElement( ElementName = "PointCardId_Z"   )]
      public short gxTpr_Pointcardid_Z
      {
         get {
            return gxTv_SdtPointCard_Pointcardid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Pointcardid_Z = value;
            SetDirty("Pointcardid_Z");
         }

      }

      public void gxTv_SdtPointCard_Pointcardid_Z_SetNull( )
      {
         gxTv_SdtPointCard_Pointcardid_Z = 0;
         SetDirty("Pointcardid_Z");
         return  ;
      }

      public bool gxTv_SdtPointCard_Pointcardid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerId_Z" )]
      [  XmlElement( ElementName = "CustomerId_Z"   )]
      public short gxTpr_Customerid_Z
      {
         get {
            return gxTv_SdtPointCard_Customerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Customerid_Z = value;
            SetDirty("Customerid_Z");
         }

      }

      public void gxTv_SdtPointCard_Customerid_Z_SetNull( )
      {
         gxTv_SdtPointCard_Customerid_Z = 0;
         SetDirty("Customerid_Z");
         return  ;
      }

      public bool gxTv_SdtPointCard_Customerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CustomerName_Z" )]
      [  XmlElement( ElementName = "CustomerName_Z"   )]
      public string gxTpr_Customername_Z
      {
         get {
            return gxTv_SdtPointCard_Customername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Customername_Z = value;
            SetDirty("Customername_Z");
         }

      }

      public void gxTv_SdtPointCard_Customername_Z_SetNull( )
      {
         gxTv_SdtPointCard_Customername_Z = "";
         SetDirty("Customername_Z");
         return  ;
      }

      public bool gxTv_SdtPointCard_Customername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PointCardPoints_Z" )]
      [  XmlElement( ElementName = "PointCardPoints_Z"   )]
      public int gxTpr_Pointcardpoints_Z
      {
         get {
            return gxTv_SdtPointCard_Pointcardpoints_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Pointcardpoints_Z = value;
            SetDirty("Pointcardpoints_Z");
         }

      }

      public void gxTv_SdtPointCard_Pointcardpoints_Z_SetNull( )
      {
         gxTv_SdtPointCard_Pointcardpoints_Z = 0;
         SetDirty("Pointcardpoints_Z");
         return  ;
      }

      public bool gxTv_SdtPointCard_Pointcardpoints_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PointCardVIP_Z" )]
      [  XmlElement( ElementName = "PointCardVIP_Z"   )]
      public bool gxTpr_Pointcardvip_Z
      {
         get {
            return gxTv_SdtPointCard_Pointcardvip_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPointCard_Pointcardvip_Z = value;
            SetDirty("Pointcardvip_Z");
         }

      }

      public void gxTv_SdtPointCard_Pointcardvip_Z_SetNull( )
      {
         gxTv_SdtPointCard_Pointcardvip_Z = false;
         SetDirty("Pointcardvip_Z");
         return  ;
      }

      public bool gxTv_SdtPointCard_Pointcardvip_Z_IsNull( )
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
         gxTv_SdtPointCard_Customername = "";
         gxTv_SdtPointCard_Mode = "";
         gxTv_SdtPointCard_Customername_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "pointcard", "GeneXus.Programs.pointcard_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtPointCard_Pointcardid ;
      private short sdtIsNull ;
      private short gxTv_SdtPointCard_Customerid ;
      private short gxTv_SdtPointCard_Initialized ;
      private short gxTv_SdtPointCard_Pointcardid_Z ;
      private short gxTv_SdtPointCard_Customerid_Z ;
      private int gxTv_SdtPointCard_Pointcardpoints ;
      private int gxTv_SdtPointCard_Pointcardpoints_Z ;
      private string gxTv_SdtPointCard_Mode ;
      private bool gxTv_SdtPointCard_Pointcardvip ;
      private bool gxTv_SdtPointCard_Pointcardvip_Z ;
      private string gxTv_SdtPointCard_Customername ;
      private string gxTv_SdtPointCard_Customername_Z ;
   }

   [DataContract(Name = @"PointCard", Namespace = "ObligatorioShop")]
   [GxJsonSerialization("default")]
   public class SdtPointCard_RESTInterface : GxGenericCollectionItem<SdtPointCard>
   {
      public SdtPointCard_RESTInterface( ) : base()
      {
      }

      public SdtPointCard_RESTInterface( SdtPointCard psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PointCardId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Pointcardid
      {
         get {
            return sdt.gxTpr_Pointcardid ;
         }

         set {
            sdt.gxTpr_Pointcardid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Customerid
      {
         get {
            return sdt.gxTpr_Customerid ;
         }

         set {
            sdt.gxTpr_Customerid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CustomerName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Customername
      {
         get {
            return sdt.gxTpr_Customername ;
         }

         set {
            sdt.gxTpr_Customername = value;
         }

      }

      [DataMember( Name = "PointCardPoints" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Pointcardpoints
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Pointcardpoints), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Pointcardpoints = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PointCardVIP" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Pointcardvip
      {
         get {
            return sdt.gxTpr_Pointcardvip ;
         }

         set {
            sdt.gxTpr_Pointcardvip = value;
         }

      }

      public SdtPointCard sdt
      {
         get {
            return (SdtPointCard)Sdt ;
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
            sdt = new SdtPointCard() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 5 )]
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

   [DataContract(Name = @"PointCard", Namespace = "ObligatorioShop")]
   [GxJsonSerialization("default")]
   public class SdtPointCard_RESTLInterface : GxGenericCollectionItem<SdtPointCard>
   {
      public SdtPointCard_RESTLInterface( ) : base()
      {
      }

      public SdtPointCard_RESTLInterface( SdtPointCard psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PointCardId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Pointcardid
      {
         get {
            return sdt.gxTpr_Pointcardid ;
         }

         set {
            sdt.gxTpr_Pointcardid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/PointCard/{0}";
            gxuri = String.Format(gxuri,gxTpr_Pointcardid) ;
            return gxuri ;
         }

         set {
         }

      }

      public SdtPointCard sdt
      {
         get {
            return (SdtPointCard)Sdt ;
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
            sdt = new SdtPointCard() ;
         }
      }

      private string gxuri ;
   }

}
