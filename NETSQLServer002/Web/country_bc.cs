using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class country_bc : GxSilentTrn, IGxSilentTrn
   {
      public country_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public country_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1CountryId = A1CountryId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12012( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11012( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z2CountryName = A2CountryName;
         }
         if ( GX_JID == -2 )
         {
            Z1CountryId = A1CountryId;
            Z2CountryName = A2CountryName;
            Z3CountryFlag = A3CountryFlag;
            Z40000CountryFlag_GXI = A40000CountryFlag_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A1CountryId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A2CountryName = BC00014_A2CountryName[0];
            A40000CountryFlag_GXI = BC00014_A40000CountryFlag_GXI[0];
            A3CountryFlag = BC00014_A3CountryFlag[0];
            ZM011( -2) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {A2CountryName, A1CountryId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Country Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2CountryName)) )
         {
            GX_msglist.addItem("El nombre no puede estar vacio", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00016 */
         pr_default.execute(4, new Object[] {A1CountryId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1CountryId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 2) ;
            RcdFound1 = 1;
            A1CountryId = BC00013_A1CountryId[0];
            A2CountryName = BC00013_A2CountryName[0];
            A40000CountryFlag_GXI = BC00013_A40000CountryFlag_GXI[0];
            A3CountryFlag = BC00013_A3CountryFlag[0];
            Z1CountryId = A1CountryId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_010( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1CountryId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Country"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2CountryName, BC00012_A2CountryName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Country"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {A2CountryName, A3CountryFlag, A40000CountryFlag_GXI});
                     A1CountryId = BC00017_A1CountryId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Country");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00018 */
                     pr_default.execute(6, new Object[] {A2CountryName, A1CountryId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Country");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Country"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC00019 */
            pr_default.execute(7, new Object[] {A3CountryFlag, A40000CountryFlag_GXI, A1CountryId});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Country");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000110 */
                  pr_default.execute(8, new Object[] {A1CountryId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Country");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000111 */
            pr_default.execute(9, new Object[] {A1CountryId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000112 */
            pr_default.execute(10, new Object[] {A1CountryId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Customer"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000113 */
            pr_default.execute(11, new Object[] {A1CountryId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Seller"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart011( )
      {
         /* Scan By routine */
         /* Using cursor BC000114 */
         pr_default.execute(12, new Object[] {A1CountryId});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1CountryId = BC000114_A1CountryId[0];
            A2CountryName = BC000114_A2CountryName[0];
            A40000CountryFlag_GXI = BC000114_A40000CountryFlag_GXI[0];
            A3CountryFlag = BC000114_A3CountryFlag[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1CountryId = BC000114_A1CountryId[0];
            A2CountryName = BC000114_A2CountryName[0];
            A40000CountryFlag_GXI = BC000114_A40000CountryFlag_GXI[0];
            A3CountryFlag = BC000114_A3CountryFlag[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcCountry) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcCountry, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A2CountryName = "";
         A3CountryFlag = "";
         A40000CountryFlag_GXI = "";
         Z2CountryName = "";
      }

      protected void InitAll011( )
      {
         A1CountryId = 0;
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow1( SdtCountry obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Countryname = A2CountryName;
         obj1.gxTpr_Countryflag = A3CountryFlag;
         obj1.gxTpr_Countryflag_gxi = A40000CountryFlag_GXI;
         obj1.gxTpr_Countryid = A1CountryId;
         obj1.gxTpr_Countryid_Z = Z1CountryId;
         obj1.gxTpr_Countryname_Z = Z2CountryName;
         obj1.gxTpr_Countryflag_gxi_Z = Z40000CountryFlag_GXI;
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( SdtCountry obj1 )
      {
         obj1.gxTpr_Countryid = A1CountryId;
         return  ;
      }

      public void RowToVars1( SdtCountry obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A2CountryName = obj1.gxTpr_Countryname;
         A3CountryFlag = obj1.gxTpr_Countryflag;
         A40000CountryFlag_GXI = obj1.gxTpr_Countryflag_gxi;
         A1CountryId = obj1.gxTpr_Countryid;
         Z1CountryId = obj1.gxTpr_Countryid_Z;
         Z2CountryName = obj1.gxTpr_Countryname_Z;
         Z40000CountryFlag_GXI = obj1.gxTpr_Countryflag_gxi_Z;
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1CountryId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1CountryId = A1CountryId;
         }
         ZM011( -2) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars1( bcCountry, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1CountryId = A1CountryId;
         }
         ZM011( -2) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1CountryId != Z1CountryId )
               {
                  A1CountryId = Z1CountryId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update011( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A1CountryId != Z1CountryId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcCountry, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcCountry) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcCountry, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcCountry) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow1( bcCountry) ;
         }
         else
         {
            SdtCountry auxBC = new SdtCountry(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1CountryId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCountry);
               auxBC.Save();
               bcCountry.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcCountry, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcCountry, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow1( bcCountry) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow1( bcCountry) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcCountry, 0) ;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1CountryId != Z1CountryId )
            {
               A1CountryId = Z1CountryId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A1CountryId != Z1CountryId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("country_bc",pr_default);
         VarsToRow1( bcCountry) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcCountry.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCountry.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCountry )
         {
            bcCountry = (SdtCountry)(sdt);
            if ( StringUtil.StrCmp(bcCountry.gxTpr_Mode, "") == 0 )
            {
               bcCountry.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcCountry) ;
            }
            else
            {
               RowToVars1( bcCountry, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCountry.gxTpr_Mode, "") == 0 )
            {
               bcCountry.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcCountry, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCountry Country_BC
      {
         get {
            return bcCountry ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z2CountryName = "";
         A2CountryName = "";
         Z3CountryFlag = "";
         A3CountryFlag = "";
         Z40000CountryFlag_GXI = "";
         A40000CountryFlag_GXI = "";
         BC00014_A1CountryId = new short[1] ;
         BC00014_A2CountryName = new string[] {""} ;
         BC00014_A40000CountryFlag_GXI = new string[] {""} ;
         BC00014_A3CountryFlag = new string[] {""} ;
         BC00015_A2CountryName = new string[] {""} ;
         BC00016_A1CountryId = new short[1] ;
         BC00013_A1CountryId = new short[1] ;
         BC00013_A2CountryName = new string[] {""} ;
         BC00013_A40000CountryFlag_GXI = new string[] {""} ;
         BC00013_A3CountryFlag = new string[] {""} ;
         sMode1 = "";
         BC00012_A1CountryId = new short[1] ;
         BC00012_A2CountryName = new string[] {""} ;
         BC00012_A40000CountryFlag_GXI = new string[] {""} ;
         BC00012_A3CountryFlag = new string[] {""} ;
         BC00017_A1CountryId = new short[1] ;
         BC000111_A10ProductId = new short[1] ;
         BC000112_A15CustomerId = new short[1] ;
         BC000113_A6SellerId = new short[1] ;
         BC000114_A1CountryId = new short[1] ;
         BC000114_A2CountryName = new string[] {""} ;
         BC000114_A40000CountryFlag_GXI = new string[] {""} ;
         BC000114_A3CountryFlag = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.country_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1CountryId, BC00012_A2CountryName, BC00012_A40000CountryFlag_GXI, BC00012_A3CountryFlag
               }
               , new Object[] {
               BC00013_A1CountryId, BC00013_A2CountryName, BC00013_A40000CountryFlag_GXI, BC00013_A3CountryFlag
               }
               , new Object[] {
               BC00014_A1CountryId, BC00014_A2CountryName, BC00014_A40000CountryFlag_GXI, BC00014_A3CountryFlag
               }
               , new Object[] {
               BC00015_A2CountryName
               }
               , new Object[] {
               BC00016_A1CountryId
               }
               , new Object[] {
               BC00017_A1CountryId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000111_A10ProductId
               }
               , new Object[] {
               BC000112_A15CustomerId
               }
               , new Object[] {
               BC000113_A6SellerId
               }
               , new Object[] {
               BC000114_A1CountryId, BC000114_A2CountryName, BC000114_A40000CountryFlag_GXI, BC000114_A3CountryFlag
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z1CountryId ;
      private short A1CountryId ;
      private short RcdFound1 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode1 ;
      private bool returnInSub ;
      private string Z2CountryName ;
      private string A2CountryName ;
      private string Z40000CountryFlag_GXI ;
      private string A40000CountryFlag_GXI ;
      private string Z3CountryFlag ;
      private string A3CountryFlag ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00014_A1CountryId ;
      private string[] BC00014_A2CountryName ;
      private string[] BC00014_A40000CountryFlag_GXI ;
      private string[] BC00014_A3CountryFlag ;
      private string[] BC00015_A2CountryName ;
      private short[] BC00016_A1CountryId ;
      private short[] BC00013_A1CountryId ;
      private string[] BC00013_A2CountryName ;
      private string[] BC00013_A40000CountryFlag_GXI ;
      private string[] BC00013_A3CountryFlag ;
      private short[] BC00012_A1CountryId ;
      private string[] BC00012_A2CountryName ;
      private string[] BC00012_A40000CountryFlag_GXI ;
      private string[] BC00012_A3CountryFlag ;
      private short[] BC00017_A1CountryId ;
      private short[] BC000111_A10ProductId ;
      private short[] BC000112_A15CustomerId ;
      private short[] BC000113_A6SellerId ;
      private short[] BC000114_A1CountryId ;
      private string[] BC000114_A2CountryName ;
      private string[] BC000114_A40000CountryFlag_GXI ;
      private string[] BC000114_A3CountryFlag ;
      private SdtCountry bcCountry ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class country_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00012;
          prmBC00012 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00013;
          prmBC00013 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00014;
          prmBC00014 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00015;
          prmBC00015 = new Object[] {
          new ParDef("@CountryName",GXType.NVarChar,40,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00016;
          prmBC00016 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00017;
          prmBC00017 = new Object[] {
          new ParDef("@CountryName",GXType.NVarChar,40,0) ,
          new ParDef("@CountryFlag",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@CountryFlag_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Country", Fld="CountryFlag"}
          };
          Object[] prmBC00018;
          prmBC00018 = new Object[] {
          new ParDef("@CountryName",GXType.NVarChar,40,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00019;
          prmBC00019 = new Object[] {
          new ParDef("@CountryFlag",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@CountryFlag_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Country", Fld="CountryFlag"} ,
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000110;
          prmBC000110 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000111;
          prmBC000111 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000112;
          prmBC000112 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000113;
          prmBC000113 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000114;
          prmBC000114 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00012", "SELECT [CountryId], [CountryName], [CountryFlag_GXI], [CountryFlag] FROM [Country] WITH (UPDLOCK) WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00013", "SELECT [CountryId], [CountryName], [CountryFlag_GXI], [CountryFlag] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00014", "SELECT TM1.[CountryId], TM1.[CountryName], TM1.[CountryFlag_GXI], TM1.[CountryFlag] FROM [Country] TM1 WHERE TM1.[CountryId] = @CountryId ORDER BY TM1.[CountryId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00015", "SELECT [CountryName] FROM [Country] WHERE ([CountryName] = @CountryName) AND (Not ( [CountryId] = @CountryId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00016", "SELECT [CountryId] FROM [Country] WHERE [CountryId] = @CountryId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00017", "INSERT INTO [Country]([CountryName], [CountryFlag], [CountryFlag_GXI]) VALUES(@CountryName, @CountryFlag, @CountryFlag_GXI); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00017,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00018", "UPDATE [Country] SET [CountryName]=@CountryName  WHERE [CountryId] = @CountryId", GxErrorMask.GX_NOMASK,prmBC00018)
             ,new CursorDef("BC00019", "UPDATE [Country] SET [CountryFlag]=@CountryFlag, [CountryFlag_GXI]=@CountryFlag_GXI  WHERE [CountryId] = @CountryId", GxErrorMask.GX_NOMASK,prmBC00019)
             ,new CursorDef("BC000110", "DELETE FROM [Country]  WHERE [CountryId] = @CountryId", GxErrorMask.GX_NOMASK,prmBC000110)
             ,new CursorDef("BC000111", "SELECT TOP 1 [ProductId] FROM [Product] WHERE [ProductCountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000112", "SELECT TOP 1 [CustomerId] FROM [Customer] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000112,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000113", "SELECT TOP 1 [SellerId] FROM [Seller] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000113,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000114", "SELECT TM1.[CountryId], TM1.[CountryName], TM1.[CountryFlag_GXI], TM1.[CountryFlag] FROM [Country] TM1 WHERE TM1.[CountryId] = @CountryId ORDER BY TM1.[CountryId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000114,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
       }
    }

 }

}
