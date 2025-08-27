using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.general.ui {
   public class sidebaritemsdp : GXProcedure
   {
      public sidebaritemsdp( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("ObligatorioShop", true);
      }

      public sidebaritemsdp( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem>( context, "SidebarItem", "GeneXusUnanimo") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_objcol_SdtProgramNames_ProgramName1 = AV5wwProgramNames;
         new GeneXus.Programs.general.ui.listprograms(context ).execute( out  GXt_objcol_SdtProgramNames_ProgramName1) ;
         AV5wwProgramNames = GXt_objcol_SdtProgramNames_ProgramName1;
         GXt_objcol_SdtProgramNames_ProgramName1 = AV10Wwprogramnamesinteractive;
         new GeneXus.Programs.general.ui.listprogramsinteractive(context ).execute( out  GXt_objcol_SdtProgramNames_ProgramName1) ;
         AV10Wwprogramnamesinteractive = GXt_objcol_SdtProgramNames_ProgramName1;
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         Gxm2rootcol.Add(Gxm1sidebaritems, 0);
         Gxm1sidebaritems.gxTpr_Id = "Principal";
         Gxm1sidebaritems.gxTpr_Title = "Principal";
         Gxm1sidebaritems.gxTpr_Target = formatLink("principal.aspx") ;
         Gxm1sidebaritems.gxTpr_Hassubitems = false;
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         Gxm2rootcol.Add(Gxm1sidebaritems, 0);
         Gxm1sidebaritems.gxTpr_Id = "Work With";
         Gxm1sidebaritems.gxTpr_Title = "Work With";
         Gxm1sidebaritems.gxTpr_Target = "";
         Gxm1sidebaritems.gxTpr_Hassubitems = true;
         AV11GXV1 = 1;
         while ( AV11GXV1 <= AV5wwProgramNames.Count )
         {
            AV6wwProgramName = ((GeneXus.Programs.general.ui.SdtProgramNames_ProgramName)AV5wwProgramNames.Item(AV11GXV1));
            Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
            Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = AV6wwProgramName.gxTpr_Name;
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = AV6wwProgramName.gxTpr_Description;
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = AV6wwProgramName.gxTpr_Link;
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            AV11GXV1 = (int)(AV11GXV1+1);
         }
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         Gxm2rootcol.Add(Gxm1sidebaritems, 0);
         Gxm1sidebaritems.gxTpr_Id = "Interactive Screens";
         Gxm1sidebaritems.gxTpr_Title = "Interactive Screens";
         Gxm1sidebaritems.gxTpr_Target = "";
         Gxm1sidebaritems.gxTpr_Hassubitems = true;
         AV12GXV2 = 1;
         while ( AV12GXV2 <= AV10Wwprogramnamesinteractive.Count )
         {
            AV6wwProgramName = ((GeneXus.Programs.general.ui.SdtProgramNames_ProgramName)AV10Wwprogramnamesinteractive.Item(AV12GXV2));
            Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
            Gxm1sidebaritems.gxTpr_Sidebarsubitems.Add(Gxm3sidebaritems_sidebarsubitems, 0);
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Id = AV6wwProgramName.gxTpr_Name;
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Title = AV6wwProgramName.gxTpr_Description;
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Target = AV6wwProgramName.gxTpr_Link;
            Gxm3sidebaritems_sidebarsubitems.gxTpr_Hassubitems = false;
            AV12GXV2 = (int)(AV12GXV2+1);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV5wwProgramNames = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "ObligatorioShop");
         AV10Wwprogramnamesinteractive = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "ObligatorioShop");
         GXt_objcol_SdtProgramNames_ProgramName1 = new GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName>( context, "ProgramName", "ObligatorioShop");
         Gxm1sidebaritems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem(context);
         AV6wwProgramName = new GeneXus.Programs.general.ui.SdtProgramNames_ProgramName(context);
         Gxm3sidebaritems_sidebarsubitems = new GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem(context);
         /* GeneXus formulas. */
      }

      private int AV11GXV1 ;
      private int AV12GXV2 ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> AV5wwProgramNames ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> AV10Wwprogramnamesinteractive ;
      private GXBaseCollection<GeneXus.Programs.general.ui.SdtProgramNames_ProgramName> GXt_objcol_SdtProgramNames_ProgramName1 ;
      private GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem Gxm1sidebaritems ;
      private GeneXus.Programs.general.ui.SdtProgramNames_ProgramName AV6wwProgramName ;
      private GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem_SubItem Gxm3sidebaritems_sidebarsubitems ;
      private GXBaseCollection<GeneXus.Programs.genexusunanimo.SdtSidebarItems_SidebarItem> aP0_Gxm2rootcol ;
   }

}
