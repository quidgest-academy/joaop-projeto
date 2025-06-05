using ExecuteQueryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace CSGenio.business
{
    public class ReindexFunctions
    {
        public PersistentSupport sp { get; set; }
        public User user { get; set; }
        public bool Zero { get; set; }

        public ReindexFunctions(PersistentSupport sp, User user, bool Zero = false) {
            this.sp = sp;
            this.user = user;
            this.Zero = Zero;
        }   

        public void DeleteInvalidRows(CancellationToken cToken) {
            List<int> zzstateToRemove = new List<int> { 1, 11 };
            DataMatrix dm;
            sp.openConnection();

            /* --- AJFMEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmem.FldCodmem)
                .From(CSGenioAmem.AreaMEM)
                .Where(CriteriaSet.And().In(CSGenioAmem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmem model = new CSGenioAmem(user);
                model.ValCodmem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserLogin --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApsw.FldCodpsw)
                .From(CSGenioApsw.AreaPSW)
                .Where(CriteriaSet.And().In(CSGenioApsw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApsw model = new CSGenioApsw(user);
                model.ValCodpsw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcess --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_apr.FldCodascpr)
                .From(CSGenioAs_apr.AreaS_APR)
                .Where(CriteriaSet.And().In(CSGenioAs_apr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_apr model = new CSGenioAs_apr(user);
                model.ValCodascpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationEmailSignature --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nes.FldCodsigna)
                .From(CSGenioAs_nes.AreaS_NES)
                .Where(CriteriaSet.And().In(CSGenioAs_nes.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nes model = new CSGenioAs_nes(user);
                model.ValCodsigna = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationMessage --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nm.FldCodmesgs)
                .From(CSGenioAs_nm.AreaS_NM)
                .Where(CriteriaSet.And().In(CSGenioAs_nm.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nm model = new CSGenioAs_nm(user);
                model.ValCodmesgs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessArgument --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_arg.FldCodargpr)
                .From(CSGenioAs_arg.AreaS_ARG)
                .Where(CriteriaSet.And().In(CSGenioAs_arg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_arg model = new CSGenioAs_arg(user);
                model.ValCodargpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessAttachments --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_pax.FldCodpranx)
                .From(CSGenioAs_pax.AreaS_PAX)
                .Where(CriteriaSet.And().In(CSGenioAs_pax.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_pax model = new CSGenioAs_pax(user);
                model.ValCodpranx = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserAuthorization --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_ua.FldCodua)
                .From(CSGenioAs_ua.AreaS_UA)
                .Where(CriteriaSet.And().In(CSGenioAs_ua.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_ua model = new CSGenioAs_ua(user);
                model.ValCodua = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                
            
            //Hard Coded Tabels
            //These can be directly removed

            /* --- AJFmem --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFmem")
                .Where(CriteriaSet.And().In("AJFmem", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFcfg")
                .Where(CriteriaSet.And().In("AJFcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFlstusr --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFlstusr")
                .Where(CriteriaSet.And().In("AJFlstusr", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFlstcol --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFlstcol")
                .Where(CriteriaSet.And().In("AJFlstcol", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFlstren --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFlstren")
                .Where(CriteriaSet.And().In("AJFlstren", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFusrwid --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFusrwid")
                .Where(CriteriaSet.And().In("AJFusrwid", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFusrcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFusrcfg")
                .Where(CriteriaSet.And().In("AJFusrcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFusrset --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFusrset")
                .Where(CriteriaSet.And().In("AJFusrset", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFwkfact --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFwkfact")
                .Where(CriteriaSet.And().In("AJFwkfact", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFwkfcon --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFwkfcon")
                .Where(CriteriaSet.And().In("AJFwkfcon", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFwkflig --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFwkflig")
                .Where(CriteriaSet.And().In("AJFwkflig", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFwkflow --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFwkflow")
                .Where(CriteriaSet.And().In("AJFwkflow", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFnotifi --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFnotifi")
                .Where(CriteriaSet.And().In("AJFnotifi", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFprmfrm --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFprmfrm")
                .Where(CriteriaSet.And().In("AJFprmfrm", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFscrcrd --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFscrcrd")
                .Where(CriteriaSet.And().In("AJFscrcrd", "ZZSTATE", zzstateToRemove)));
                
            /* --- docums --- */
            sp.Execute(new DeleteQuery()
                .Delete("docums")
                .Where(CriteriaSet.And().In("docums", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFpostit --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFpostit")
                .Where(CriteriaSet.And().In("AJFpostit", "ZZSTATE", zzstateToRemove)));
                
            /* --- hashcd --- */
            sp.Execute(new DeleteQuery()
                .Delete("hashcd")
                .Where(CriteriaSet.And().In("hashcd", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFalerta --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFalerta")
                .Where(CriteriaSet.And().In("AJFalerta", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFaltent --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFaltent")
                .Where(CriteriaSet.And().In("AJFaltent", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFtalert --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFtalert")
                .Where(CriteriaSet.And().In("AJFtalert", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFdelega --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFdelega")
                .Where(CriteriaSet.And().In("AJFdelega", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFTABDINAMIC --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFTABDINAMIC")
                .Where(CriteriaSet.And().In("AJFTABDINAMIC", "ZZSTATE", zzstateToRemove)));
                
            /* --- UserAuthorization --- */
            sp.Execute(new DeleteQuery()
                .Delete("UserAuthorization")
                .Where(CriteriaSet.And().In("UserAuthorization", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFaltran --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFaltran")
                .Where(CriteriaSet.And().In("AJFaltran", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFworkflowtask --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFworkflowtask")
                .Where(CriteriaSet.And().In("AJFworkflowtask", "ZZSTATE", zzstateToRemove)));
                
            /* --- AJFworkflowprocess --- */
            sp.Execute(new DeleteQuery()
                .Delete("AJFworkflowprocess")
                .Where(CriteriaSet.And().In("AJFworkflowprocess", "ZZSTATE", zzstateToRemove)));
                

            sp.closeConnection();
        }





        // USE /[MANUAL RDX_STEP]/
    }
}