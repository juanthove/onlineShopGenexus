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
   public class pointcard_bc : GxSilentTrn, IGxSilentTrn
   {
      public pointcard_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public pointcard_bc( IGxContext context )
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
         ReadRow066( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey066( ) ;
         standaloneModal( ) ;
         AddRow066( ) ;
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
            E11062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z20PointCardId = A20PointCardId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls066( ) ;
            }
            else
            {
               CheckExtendedTable066( ) ;
               if ( AnyError == 0 )
               {
                  ZM066( 3) ;
               }
               CloseExtendedTableCursors066( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12062( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11062( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z22PointCardPoints = A22PointCardPoints;
            Z23PointCardVIP = A23PointCardVIP;
            Z15CustomerId = A15CustomerId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z16CustomerName = A16CustomerName;
         }
         if ( GX_JID == -1 )
         {
            Z20PointCardId = A20PointCardId;
            Z22PointCardPoints = A22PointCardPoints;
            Z23PointCardVIP = A23PointCardVIP;
            Z15CustomerId = A15CustomerId;
            Z16CustomerName = A16CustomerName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load066( )
      {
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {A20PointCardId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound6 = 1;
            A16CustomerName = BC00065_A16CustomerName[0];
            A22PointCardPoints = BC00065_A22PointCardPoints[0];
            A23PointCardVIP = BC00065_A23PointCardVIP[0];
            A15CustomerId = BC00065_A15CustomerId[0];
            ZM066( -1) ;
         }
         pr_default.close(3);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
      }

      protected void CheckExtendedTable066( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00066 */
         pr_default.execute(4, new Object[] {A15CustomerId, A20PointCardId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Customer Id"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {A15CustomerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Customer'.", "ForeignKeyNotFound", 1, "CUSTOMERID");
            AnyError = 1;
         }
         A16CustomerName = BC00064_A16CustomerName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey066( )
      {
         /* Using cursor BC00067 */
         pr_default.execute(5, new Object[] {A20PointCardId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A20PointCardId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 1) ;
            RcdFound6 = 1;
            A20PointCardId = BC00063_A20PointCardId[0];
            A22PointCardPoints = BC00063_A22PointCardPoints[0];
            A23PointCardVIP = BC00063_A23PointCardVIP[0];
            A15CustomerId = BC00063_A15CustomerId[0];
            Z20PointCardId = A20PointCardId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
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
         CONFIRM_060( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A20PointCardId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PointCard"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z22PointCardPoints != BC00062_A22PointCardPoints[0] ) || ( Z23PointCardVIP != BC00062_A23PointCardVIP[0] ) || ( Z15CustomerId != BC00062_A15CustomerId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PointCard"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00068 */
                     pr_default.execute(6, new Object[] {A22PointCardPoints, A23PointCardVIP, A15CustomerId});
                     A20PointCardId = BC00068_A20PointCardId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("PointCard");
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00069 */
                     pr_default.execute(7, new Object[] {A22PointCardPoints, A23PointCardVIP, A15CustomerId, A20PointCardId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("PointCard");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PointCard"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000610 */
                  pr_default.execute(8, new Object[] {A20PointCardId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("PointCard");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel066( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000611 */
            pr_default.execute(9, new Object[] {A15CustomerId});
            A16CustomerName = BC000611_A16CustomerName[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
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

      public void ScanKeyStart066( )
      {
         /* Scan By routine */
         /* Using cursor BC000612 */
         pr_default.execute(10, new Object[] {A20PointCardId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound6 = 1;
            A20PointCardId = BC000612_A20PointCardId[0];
            A16CustomerName = BC000612_A16CustomerName[0];
            A22PointCardPoints = BC000612_A22PointCardPoints[0];
            A23PointCardVIP = BC000612_A23PointCardVIP[0];
            A15CustomerId = BC000612_A15CustomerId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound6 = 0;
         ScanKeyLoad066( ) ;
      }

      protected void ScanKeyLoad066( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound6 = 1;
            A20PointCardId = BC000612_A20PointCardId[0];
            A16CustomerName = BC000612_A16CustomerName[0];
            A22PointCardPoints = BC000612_A22PointCardPoints[0];
            A23PointCardVIP = BC000612_A23PointCardVIP[0];
            A15CustomerId = BC000612_A15CustomerId[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd066( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void AddRow066( )
      {
         VarsToRow6( bcPointCard) ;
      }

      protected void ReadRow066( )
      {
         RowToVars6( bcPointCard, 1) ;
      }

      protected void InitializeNonKey066( )
      {
         A15CustomerId = 0;
         A16CustomerName = "";
         A22PointCardPoints = 0;
         A23PointCardVIP = false;
         Z22PointCardPoints = 0;
         Z23PointCardVIP = false;
         Z15CustomerId = 0;
      }

      protected void InitAll066( )
      {
         A20PointCardId = 0;
         InitializeNonKey066( ) ;
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

      public void VarsToRow6( SdtPointCard obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Customerid = A15CustomerId;
         obj6.gxTpr_Customername = A16CustomerName;
         obj6.gxTpr_Pointcardpoints = A22PointCardPoints;
         obj6.gxTpr_Pointcardvip = A23PointCardVIP;
         obj6.gxTpr_Pointcardid = A20PointCardId;
         obj6.gxTpr_Pointcardid_Z = Z20PointCardId;
         obj6.gxTpr_Customerid_Z = Z15CustomerId;
         obj6.gxTpr_Customername_Z = Z16CustomerName;
         obj6.gxTpr_Pointcardpoints_Z = Z22PointCardPoints;
         obj6.gxTpr_Pointcardvip_Z = Z23PointCardVIP;
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( SdtPointCard obj6 )
      {
         obj6.gxTpr_Pointcardid = A20PointCardId;
         return  ;
      }

      public void RowToVars6( SdtPointCard obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A15CustomerId = obj6.gxTpr_Customerid;
         A16CustomerName = obj6.gxTpr_Customername;
         A22PointCardPoints = obj6.gxTpr_Pointcardpoints;
         A23PointCardVIP = obj6.gxTpr_Pointcardvip;
         A20PointCardId = obj6.gxTpr_Pointcardid;
         Z20PointCardId = obj6.gxTpr_Pointcardid_Z;
         Z15CustomerId = obj6.gxTpr_Customerid_Z;
         Z16CustomerName = obj6.gxTpr_Customername_Z;
         Z22PointCardPoints = obj6.gxTpr_Pointcardpoints_Z;
         Z23PointCardVIP = obj6.gxTpr_Pointcardvip_Z;
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A20PointCardId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey066( ) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z20PointCardId = A20PointCardId;
         }
         ZM066( -1) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
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
         RowToVars6( bcPointCard, 0) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z20PointCardId = A20PointCardId;
         }
         ZM066( -1) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert066( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A20PointCardId != Z20PointCardId )
               {
                  A20PointCardId = Z20PointCardId;
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
                  Update066( ) ;
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
                  if ( A20PointCardId != Z20PointCardId )
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
                        Insert066( ) ;
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
                        Insert066( ) ;
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
         RowToVars6( bcPointCard, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcPointCard) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcPointCard, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcPointCard) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow6( bcPointCard) ;
         }
         else
         {
            SdtPointCard auxBC = new SdtPointCard(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A20PointCardId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPointCard);
               auxBC.Save();
               bcPointCard.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars6( bcPointCard, 1) ;
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
         RowToVars6( bcPointCard, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
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
               VarsToRow6( bcPointCard) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow6( bcPointCard) ;
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
         RowToVars6( bcPointCard, 0) ;
         GetKey066( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A20PointCardId != Z20PointCardId )
            {
               A20PointCardId = Z20PointCardId;
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
            if ( A20PointCardId != Z20PointCardId )
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
         pr_default.close(9);
         context.RollbackDataStores("pointcard_bc",pr_default);
         VarsToRow6( bcPointCard) ;
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
         Gx_mode = bcPointCard.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPointCard.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPointCard )
         {
            bcPointCard = (SdtPointCard)(sdt);
            if ( StringUtil.StrCmp(bcPointCard.gxTpr_Mode, "") == 0 )
            {
               bcPointCard.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcPointCard) ;
            }
            else
            {
               RowToVars6( bcPointCard, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPointCard.gxTpr_Mode, "") == 0 )
            {
               bcPointCard.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcPointCard, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPointCard PointCard_BC
      {
         get {
            return bcPointCard ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z16CustomerName = "";
         A16CustomerName = "";
         BC00065_A20PointCardId = new short[1] ;
         BC00065_A16CustomerName = new string[] {""} ;
         BC00065_A22PointCardPoints = new int[1] ;
         BC00065_A23PointCardVIP = new bool[] {false} ;
         BC00065_A15CustomerId = new short[1] ;
         BC00066_A15CustomerId = new short[1] ;
         BC00064_A16CustomerName = new string[] {""} ;
         BC00067_A20PointCardId = new short[1] ;
         BC00063_A20PointCardId = new short[1] ;
         BC00063_A22PointCardPoints = new int[1] ;
         BC00063_A23PointCardVIP = new bool[] {false} ;
         BC00063_A15CustomerId = new short[1] ;
         sMode6 = "";
         BC00062_A20PointCardId = new short[1] ;
         BC00062_A22PointCardPoints = new int[1] ;
         BC00062_A23PointCardVIP = new bool[] {false} ;
         BC00062_A15CustomerId = new short[1] ;
         BC00068_A20PointCardId = new short[1] ;
         BC000611_A16CustomerName = new string[] {""} ;
         BC000612_A20PointCardId = new short[1] ;
         BC000612_A16CustomerName = new string[] {""} ;
         BC000612_A22PointCardPoints = new int[1] ;
         BC000612_A23PointCardVIP = new bool[] {false} ;
         BC000612_A15CustomerId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pointcard_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A20PointCardId, BC00062_A22PointCardPoints, BC00062_A23PointCardVIP, BC00062_A15CustomerId
               }
               , new Object[] {
               BC00063_A20PointCardId, BC00063_A22PointCardPoints, BC00063_A23PointCardVIP, BC00063_A15CustomerId
               }
               , new Object[] {
               BC00064_A16CustomerName
               }
               , new Object[] {
               BC00065_A20PointCardId, BC00065_A16CustomerName, BC00065_A22PointCardPoints, BC00065_A23PointCardVIP, BC00065_A15CustomerId
               }
               , new Object[] {
               BC00066_A15CustomerId
               }
               , new Object[] {
               BC00067_A20PointCardId
               }
               , new Object[] {
               BC00068_A20PointCardId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000611_A16CustomerName
               }
               , new Object[] {
               BC000612_A20PointCardId, BC000612_A16CustomerName, BC000612_A22PointCardPoints, BC000612_A23PointCardVIP, BC000612_A15CustomerId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12062 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z20PointCardId ;
      private short A20PointCardId ;
      private short Z15CustomerId ;
      private short A15CustomerId ;
      private short RcdFound6 ;
      private int trnEnded ;
      private int Z22PointCardPoints ;
      private int A22PointCardPoints ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode6 ;
      private bool returnInSub ;
      private bool Z23PointCardVIP ;
      private bool A23PointCardVIP ;
      private string Z16CustomerName ;
      private string A16CustomerName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00065_A20PointCardId ;
      private string[] BC00065_A16CustomerName ;
      private int[] BC00065_A22PointCardPoints ;
      private bool[] BC00065_A23PointCardVIP ;
      private short[] BC00065_A15CustomerId ;
      private short[] BC00066_A15CustomerId ;
      private string[] BC00064_A16CustomerName ;
      private short[] BC00067_A20PointCardId ;
      private short[] BC00063_A20PointCardId ;
      private int[] BC00063_A22PointCardPoints ;
      private bool[] BC00063_A23PointCardVIP ;
      private short[] BC00063_A15CustomerId ;
      private short[] BC00062_A20PointCardId ;
      private int[] BC00062_A22PointCardPoints ;
      private bool[] BC00062_A23PointCardVIP ;
      private short[] BC00062_A15CustomerId ;
      private short[] BC00068_A20PointCardId ;
      private string[] BC000611_A16CustomerName ;
      private short[] BC000612_A20PointCardId ;
      private string[] BC000612_A16CustomerName ;
      private int[] BC000612_A22PointCardPoints ;
      private bool[] BC000612_A23PointCardVIP ;
      private short[] BC000612_A15CustomerId ;
      private SdtPointCard bcPointCard ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class pointcard_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00062;
          prmBC00062 = new Object[] {
          new ParDef("@PointCardId",GXType.Int16,4,0)
          };
          Object[] prmBC00063;
          prmBC00063 = new Object[] {
          new ParDef("@PointCardId",GXType.Int16,4,0)
          };
          Object[] prmBC00064;
          prmBC00064 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC00065;
          prmBC00065 = new Object[] {
          new ParDef("@PointCardId",GXType.Int16,4,0)
          };
          Object[] prmBC00066;
          prmBC00066 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0) ,
          new ParDef("@PointCardId",GXType.Int16,4,0)
          };
          Object[] prmBC00067;
          prmBC00067 = new Object[] {
          new ParDef("@PointCardId",GXType.Int16,4,0)
          };
          Object[] prmBC00068;
          prmBC00068 = new Object[] {
          new ParDef("@PointCardPoints",GXType.Int32,8,0) ,
          new ParDef("@PointCardVIP",GXType.Boolean,4,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC00069;
          prmBC00069 = new Object[] {
          new ParDef("@PointCardPoints",GXType.Int32,8,0) ,
          new ParDef("@PointCardVIP",GXType.Boolean,4,0) ,
          new ParDef("@CustomerId",GXType.Int16,4,0) ,
          new ParDef("@PointCardId",GXType.Int16,4,0)
          };
          Object[] prmBC000610;
          prmBC000610 = new Object[] {
          new ParDef("@PointCardId",GXType.Int16,4,0)
          };
          Object[] prmBC000611;
          prmBC000611 = new Object[] {
          new ParDef("@CustomerId",GXType.Int16,4,0)
          };
          Object[] prmBC000612;
          prmBC000612 = new Object[] {
          new ParDef("@PointCardId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00062", "SELECT [PointCardId], [PointCardPoints], [PointCardVIP], [CustomerId] FROM [PointCard] WITH (UPDLOCK) WHERE [PointCardId] = @PointCardId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00063", "SELECT [PointCardId], [PointCardPoints], [PointCardVIP], [CustomerId] FROM [PointCard] WHERE [PointCardId] = @PointCardId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00064", "SELECT [CustomerName] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00065", "SELECT TM1.[PointCardId], T2.[CustomerName], TM1.[PointCardPoints], TM1.[PointCardVIP], TM1.[CustomerId] FROM ([PointCard] TM1 INNER JOIN [Customer] T2 ON T2.[CustomerId] = TM1.[CustomerId]) WHERE TM1.[PointCardId] = @PointCardId ORDER BY TM1.[PointCardId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00066", "SELECT [CustomerId] FROM [PointCard] WHERE ([CustomerId] = @CustomerId) AND (Not ( [PointCardId] = @PointCardId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00067", "SELECT [PointCardId] FROM [PointCard] WHERE [PointCardId] = @PointCardId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00068", "INSERT INTO [PointCard]([PointCardPoints], [PointCardVIP], [CustomerId]) VALUES(@PointCardPoints, @PointCardVIP, @CustomerId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00068,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00069", "UPDATE [PointCard] SET [PointCardPoints]=@PointCardPoints, [PointCardVIP]=@PointCardVIP, [CustomerId]=@CustomerId  WHERE [PointCardId] = @PointCardId", GxErrorMask.GX_NOMASK,prmBC00069)
             ,new CursorDef("BC000610", "DELETE FROM [PointCard]  WHERE [PointCardId] = @PointCardId", GxErrorMask.GX_NOMASK,prmBC000610)
             ,new CursorDef("BC000611", "SELECT [CustomerName] FROM [Customer] WHERE [CustomerId] = @CustomerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000612", "SELECT TM1.[PointCardId], T2.[CustomerName], TM1.[PointCardPoints], TM1.[PointCardVIP], TM1.[CustomerId] FROM ([PointCard] TM1 INNER JOIN [Customer] T2 ON T2.[CustomerId] = TM1.[CustomerId]) WHERE TM1.[PointCardId] = @PointCardId ORDER BY TM1.[PointCardId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000612,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
