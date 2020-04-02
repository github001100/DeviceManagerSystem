using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMES.Entity.SYS
{
    public class ldkpApi
    {
        #region 实体成员
        /// <summary>
        /// id
        /// </summary>
        /// <returns></returns>
        public string id { get; set; }
        /// <summary>
        /// lz_SN
        /// </summary>
        /// <returns></returns>
        public string lz_SN { get; set; }
        /// <summary>
        /// lz_QRcode
        /// </summary>
        /// <returns></returns>
        public string lz_QRcode { get; set; }
        /// <summary>
        /// zh
        /// </summary>
        /// <returns></returns>
        public string zh { get; set; }
        /// <summary>
        /// rlh
        /// </summary>
        /// <returns></returns>
        public string rlh { get; set; }
        /// <summary>
        /// clbj_z
        /// </summary>
        /// <returns></returns>
        public string clbj_z { get; set; }
        /// <summary>
        /// clbj_y
        /// </summary>
        /// <returns></returns>
        public string clbj_y { get; set; }
        /// <summary>
        /// in_srdw
        /// </summary>
        /// <returns></returns>
        public string in_srdw { get; set; }
        /// <summary>
        /// in_srrq
        /// </summary>
        /// <returns></returns>
        public string in_srrq { get; set; }
        /// <summary>
        /// in_zh
        /// </summary>
        /// <returns></returns>
        public string in_zh { get; set; }
        /// <summary>
        /// zhouxing
        /// </summary>
        /// <returns></returns>
        public string zhouxing { get; set; }//id,lz_SN,lz_QRcode,zh,rlh,clbj_z,clbj_y,in_srdw,in_zh
        /// <summary>
        /// in_zxhcz
        /// </summary>
        /// <returns></returns>
        public string in_zxhcz { get; set; }
        /// <summary>
        /// in_lx
        /// </summary>
        /// <returns></returns>
        public string in_lx { get; set; }
        /// <summary>
        /// in_cz_zzrq
        /// </summary>
        /// <returns></returns>
        public string in_cz_zzrq { get; set; }
        /// <summary>
        /// in_cz_zzdw
        /// </summary>
        /// <returns></returns>
        public string in_cz_zzdw { get; set; }
        /// <summary>
        /// in_ld_sczzrq
        /// </summary>
        /// <returns></returns>
        public string in_ld_sczzrq { get; set; }
        /// <summary>
        /// in_ld_sczzdw
        /// </summary>
        /// <returns></returns>
        public string in_ld_sczzdw { get; set; }
        /// <summary>
        /// in_ld_mczzrq
        /// </summary>
        /// <returns></returns>
        public string in_ld_mczzrq { get; set; }
        /// <summary>
        /// in_ld_mczzdw
        /// </summary>
        /// <returns></returns>
        public string in_ld_mczzdw { get; set; }
        /// <summary>
        /// in_srly_db
        /// </summary>
        /// <returns></returns>
        public string in_srly_db { get; set; }
        /// <summary>
        /// in_srly_czcxch
        /// </summary>
        /// <returns></returns>
        public string in_srly_czcxch { get; set; }
        /// <summary>
        /// in_srly_zw
        /// </summary>
        /// <returns></returns>
        public string in_srly_zw { get; set; }
        /// <summary>
        /// in_srly_yy
        /// </summary>
        /// <returns></returns>
        public string in_srly_yy { get; set; }
        /// <summary>
        /// in_srly_yy_qt
        /// </summary>
        /// <returns></returns>
        public string in_srly_yy_qt { get; set; }
        /// <summary>
        /// in_lxgz
        /// </summary>
        /// <returns></returns>
        public string in_lxgz { get; set; }
        /// <summary>
        /// in_lxgz_qt
        /// </summary>
        /// <returns></returns>
        public string in_lxgz_qt { get; set; }
        /// <summary>
        /// in_zzlx
        /// </summary>
        /// <returns></returns>
        public string in_zzlx { get; set; }
        /// <summary>
        /// in_zczxlx
        /// </summary>
        /// <returns></returns>
        public string in_zczxlx { get; set; }
        /// <summary>
        /// in_zdp
        /// </summary>
        /// <returns></returns>
        public string in_zdp { get; set; }
        /// <summary>
        /// in_jcz
        /// </summary>
        /// <returns></returns>
        public string in_jcz { get; set; }
        /// <summary>
        /// jc_zdlsk_z
        /// </summary>
        /// <returns></returns>
        public string jc_zdlsk_z { get; set; }
        /// <summary>
        /// jc_zdlsk_y
        /// </summary>
        /// <returns></returns>
        public string jc_zdlsk_y { get; set; }
        /// <summary>
        /// jc_zdlsk_jcz
        /// </summary>
        /// <returns></returns>
        public string jc_zdlsk_jcz { get; set; }
        /// <summary>
        /// jc_zdp_z
        /// </summary>
        /// <returns></returns>
        public string jc_zdp_z { get; set; }
        /// <summary>
        /// jc_zdp_zz
        /// </summary>
        /// <returns></returns>
        public string jc_zdp_zz { get; set; }
        /// <summary>
        /// jc_zdp_y
        /// </summary>
        /// <returns></returns>
        public string jc_zdp_y { get; set; }
        /// <summary>
        /// jc_zdp_jcz
        /// </summary>
        /// <returns></returns>
        public string jc_zdp_jcz { get; set; }
        /// <summary>
        /// qdxc_jg
        /// </summary>
        /// <returns></returns>
        public string qdxc_jg { get; set; }
        /// <summary>
        /// qdxc_jg_yy
        /// </summary>
        /// <returns></returns>
        public string qdxc_jg_yy { get; set; }
        /// <summary>
        /// qdxc_jcz
        /// </summary>
        /// <returns></returns>
        public string qdxc_jcz { get; set; }
        /// <summary>
        /// ts_cfts_zjjfcbz
        /// </summary>
        /// <returns></returns>
        public string ts_cfts_zjjfcbz { get; set; }
        /// <summary>
        /// ts_cfts_zjjfcbz_jcz
        /// </summary>
        /// <returns></returns>
        public string ts_cfts_zjjfcbz_jcz { get; set; }
        /// <summary>
        /// ts_cfts_zs
        /// </summary>
        /// <returns></returns>
        public string ts_cfts_zs { get; set; }
        /// <summary>
        /// ts_cfts_zs_jcz
        /// </summary>
        /// <returns></returns>
        public string ts_cfts_zs_jcz { get; set; }
        /// <summary>
        /// ts_cfts_cl
        /// </summary>
        /// <returns></returns>
        public string ts_cfts_cl { get; set; }
        /// <summary>
        /// ts_cfts_cl_jcz
        /// </summary>
        /// <returns></returns>
        public string ts_cfts_cl_jcz { get; set; }
        /// <summary>
        /// ts_cfts_zdp
        /// </summary>
        /// <returns></returns>
        public string ts_cfts_zdp { get; set; }
        /// <summary>
        /// ts_cfts_zdp_jcz
        /// </summary>
        /// <returns></returns>
        public string ts_cfts_zdp_jcz { get; set; }
        /// <summary>
        /// ts_cfts_tsz
        /// </summary>
        /// <returns></returns>
        public string ts_cfts_tsz { get; set; }
        /// <summary>
        /// ts_csbts_wjts
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_wjts { get; set; }
        /// <summary>
        /// ts_csbts_wjts_jcz
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_wjts_jcz { get; set; }
        /// <summary>
        /// ts_csbts_czct
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_czct { get; set; }
        /// <summary>
        /// ts_csbts_czct_jcz
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_czct_jcz { get; set; }
        /// <summary>
        /// ts_csbts_lz
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_lz { get; set; }
        /// <summary>
        /// ts_csbts_lz_jcz
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_lz_jcz { get; set; }
        /// <summary>
        /// ts_csbts_zdpz
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_zdpz { get; set; }
        /// <summary>
        /// ts_csbts_zdpz_jcz
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_zdpz_jcz { get; set; }
        /// <summary>
        /// ts_csbts_xhc
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_xhc { get; set; }
        /// <summary>
        /// ts_csbts_xhc_jcz
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_xhc_jcz { get; set; }
        /// <summary>
        /// ts_csbts_lw
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_lw { get; set; }
        /// <summary>
        /// ts_csbts_lw_jcz
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_lw_jcz { get; set; }
        /// <summary>
        /// ts_csbts_tsz
        /// </summary>
        /// <returns></returns>
        public string ts_csbts_tsz { get; set; }
        /// <summary>
        /// cz_zszj_srcc
        /// </summary>
        /// <returns></returns>
        public string cz_zszj_srcc { get; set; }
        /// <summary>
        /// cz_zszj_zccc
        /// </summary>
        /// <returns></returns>
        public string cz_zszj_zccc { get; set; }
        /// <summary>
        /// cz_zjzj_srcc_z
        /// </summary>
        /// <returns></returns>
        public string cz_zjzj_srcc_z { get; set; }
        /// <summary>
        /// cz_zjzj_srcc_y
        /// </summary>
        /// <returns></returns>
        public string cz_zjzj_srcc_y { get; set; }
        /// <summary>
        /// cz_zjzj_zccc_z
        /// </summary>
        /// <returns></returns>
        public string cz_zjzj_zccc_z { get; set; }
        /// <summary>
        /// cz_zjzj_zccc_y
        /// </summary>
        /// <returns></returns>
        public string cz_zjzj_zccc_y { get; set; }
        /// <summary>
        /// cz_fcbzzj_srcc_z
        /// </summary>
        /// <returns></returns>
        public string cz_fcbzzj_srcc_z { get; set; }
        /// <summary>
        /// cz_fcbzzj_srcc_y
        /// </summary>
        /// <returns></returns>
        public string cz_fcbzzj_srcc_y { get; set; }
        /// <summary>
        /// cz_fcbzzj_zccc_z
        /// </summary>
        /// <returns></returns>
        public string cz_fcbzzj_zccc_z { get; set; }
        /// <summary>
        /// cz_fcbzzj_zccc_y
        /// </summary>
        /// <returns></returns>
        public string cz_fcbzzj_zccc_y { get; set; }
        /// <summary>
        /// cl_lwh_srcc_z
        /// </summary>
        /// <returns></returns>
        public string cl_lwh_srcc_z { get; set; }
        /// <summary>
        /// cl_lwh_srcc_y
        /// </summary>
        /// <returns></returns>
        public string cl_lwh_srcc_y { get; set; }
        /// <summary>
        /// cl_lwh_zccc_z
        /// </summary>
        /// <returns></returns>
        public string cl_lwh_zccc_z { get; set; }
        /// <summary>
        /// cl_lwh_zccc_y
        /// </summary>
        /// <returns></returns>
        public string cl_lwh_zccc_y { get; set; }
        /// <summary>
        /// cl_lwk_srcc_z
        /// </summary>
        /// <returns></returns>
        public string cl_lwk_srcc_z { get; set; }
        /// <summary>
        /// cl_lwk_srcc_y
        /// </summary>
        /// <returns></returns>
        public string cl_lwk_srcc_y { get; set; }
        /// <summary>
        /// cl_lwk_zccc_z
        /// </summary>
        /// <returns></returns>
        public string cl_lwk_zccc_z { get; set; }
        /// <summary>
        /// cl_lwk_zccc_y
        /// </summary>
        /// <returns></returns>
        public string cl_lwk_zccc_y { get; set; }
        /// <summary>
        /// cl_lyh_srcc_z
        /// </summary>
        /// <returns></returns>
        public string cl_lyh_srcc_z { get; set; }
        /// <summary>
        /// cl_lyh_srcc_y
        /// </summary>
        /// <returns></returns>
        public string cl_lyh_srcc_y { get; set; }
        /// <summary>
        /// cl_lyh_zccc_z
        /// </summary>
        /// <returns></returns>
        public string cl_lyh_zccc_z { get; set; }
        /// <summary>
        /// cl_lyh_zccc_y
        /// </summary>
        /// <returns></returns>
        public string cl_lyh_zccc_y { get; set; }
        /// <summary>
        /// cl_tmyzmh_srcc_z
        /// </summary>
        /// <returns></returns>
        public string cl_tmyzmh_srcc_z { get; set; }
        /// <summary>
        /// cl_tmyzmh_srcc_y
        /// </summary>
        /// <returns></returns>
        public string cl_tmyzmh_srcc_y { get; set; }
        /// <summary>
        /// cl_tmyzmh_zccc_z
        /// </summary>
        /// <returns></returns>
        public string cl_tmyzmh_zccc_z { get; set; }
        /// <summary>
        /// cl_tmyzmh_zccc_y
        /// </summary>
        /// <returns></returns>
        public string cl_tmyzmh_zccc_y { get; set; }
        /// <summary>
        /// cl_zj_srcc_z
        /// </summary>
        /// <returns></returns>
        public string cl_zj_srcc_z { get; set; }
        /// <summary>
        /// cl_zj_srcc_y
        /// </summary>
        /// <returns></returns>
        public string cl_zj_srcc_y { get; set; }
        /// <summary>
        /// cl_zj_zccc_z
        /// </summary>
        /// <returns></returns>
        public string cl_zj_zccc_z { get; set; }
        /// <summary>
        /// cl_zj_zccc_y
        /// </summary>
        /// <returns></returns>
        public string cl_zj_zccc_y { get; set; }
        /// <summary>
        /// ld_tmyjm_zccc_z
        /// </summary>
        /// <returns></returns>
        public string ld_tmyjm_zccc_z { get; set; }
        /// <summary>
        /// ld_tmyjm_zccc_y
        /// </summary>
        /// <returns></returns>
        public string ld_tmyjm_zccc_y { get; set; }
        /// <summary>
        /// ld_cyd_zccc_z
        /// </summary>
        /// <returns></returns>
        public string ld_cyd_zccc_z { get; set; }
        /// <summary>
        /// ld_cyd_zccc_y
        /// </summary>
        /// <returns></returns>
        public string ld_cyd_zccc_y { get; set; }
        /// <summary>
        /// ld_lwc_srcc
        /// </summary>
        /// <returns></returns>
        public string ld_lwc_srcc { get; set; }
        /// <summary>
        /// ld_lwc_srcc_z
        /// </summary>
        /// <returns></returns>
        public string ld_lwc_srcc_z { get; set; }
        /// <summary>
        /// ld_lwc_srcc_y
        /// </summary>
        /// <returns></returns>
        public string ld_lwc_srcc_y { get; set; }
        /// <summary>
        /// ld_lwc_zccc
        /// </summary>
        /// <returns></returns>
        public string ld_lwc_zccc { get; set; }
        /// <summary>
        /// ld_lwc_zccc_z
        /// </summary>
        /// <returns></returns>
        public string ld_lwc_zccc_z { get; set; }
        /// <summary>
        /// ld_lwc_zccc_y
        /// </summary>
        /// <returns></returns>
        public string ld_lwc_zccc_y { get; set; }
        /// <summary>
        /// ld_ldpmh_srcc_z
        /// </summary>
        /// <returns></returns>
        public string ld_ldpmh_srcc_z { get; set; }
        /// <summary>
        /// ld_ldpmh_srcc_zj
        /// </summary>
        /// <returns></returns>
        public string ld_ldpmh_srcc_zj { get; set; }
        /// <summary>
        /// ld_ldpmh_srcc_y
        /// </summary>
        /// <returns></returns>
        public string ld_ldpmh_srcc_y { get; set; }
        /// <summary>
        /// ld_ldpmh_zccc_z
        /// </summary>
        /// <returns></returns>
        public string ld_ldpmh_zccc_z { get; set; }
        /// <summary>
        /// ld_ldpmh_zccc_zj
        /// </summary>
        /// <returns></returns>
        public string ld_ldpmh_zccc_zj { get; set; }
        /// <summary>
        /// ld_ldpmh_zccc_y
        /// </summary>
        /// <returns></returns>
        public string ld_ldpmh_zccc_y { get; set; }
        /// <summary>
        /// ld_ncj_srcc_1
        /// </summary>
        /// <returns></returns>
        public string ld_ncj_srcc_1 { get; set; }
        /// <summary>
        /// ld_ncj_srcc_2
        /// </summary>
        /// <returns></returns>
        public string ld_ncj_srcc_2 { get; set; }
        /// <summary>
        /// ld_ncj_srcc_3
        /// </summary>
        /// <returns></returns>
        public string ld_ncj_srcc_3 { get; set; }
        /// <summary>
        /// ld_ncj_srcc_c
        /// </summary>
        /// <returns></returns>
        public string ld_ncj_srcc_c { get; set; }
        /// <summary>
        /// ld_ncj_zccc_1
        /// </summary>
        /// <returns></returns>
        public string ld_ncj_zccc_1 { get; set; }
        /// <summary>
        /// ld_ncj_zccc_2
        /// </summary>
        /// <returns></returns>
        public string ld_ncj_zccc_2 { get; set; }
        /// <summary>
        /// ld_ncj_zccc_3
        /// </summary>
        /// <returns></returns>
        public string ld_ncj_zccc_3 { get; set; }
        /// <summary>
        /// ld_ncj_zccc_c
        /// </summary>
        /// <returns></returns>
        public string ld_ncj_zccc_c { get; set; }
        /// <summary>
        /// cc_srcc_jcz
        /// </summary>
        /// <returns></returns>
        public string cc_srcc_jcz { get; set; }
        /// <summary>
        /// cc_zccc_jcz
        /// </summary>
        /// <returns></returns>
        public string cc_zccc_jcz { get; set; }
        /// <summary>
        /// cc_zccc_sj
        /// </summary>
        /// <returns></returns>
        public DateTime? cc_zccc_sj { get; set; }
        /// <summary>
        /// cc_zccc_zt
        /// </summary>
        /// <returns></returns>
        public string cc_zccc_zt { get; set; }
        /// <summary>
        /// zc_zcdw
        /// </summary>
        /// <returns></returns>
        public string zc_zcdw { get; set; }
        /// <summary>
        /// zc_rq
        /// </summary>
        /// <returns></returns>
        public string zc_rq { get; set; }
        /// <summary>
        /// zc_zccs_dw
        /// </summary>
        /// <returns></returns>
        public string zc_zccs_dw { get; set; }
        /// <summary>
        /// zc_zccs_czcxxh
        /// </summary>
        /// <returns></returns>
        public string zc_zccs_czcxxh { get; set; }
        /// <summary>
        /// zc_zccs_zw
        /// </summary>
        /// <returns></returns>
        public string zc_zccs_zw { get; set; }
        /// <summary>
        /// zc_zccs_xc
        /// </summary>
        /// <returns></returns>
        public string zc_zccs_xc { get; set; }
        /// <summary>
        /// xpflag
        /// </summary>
        /// <returns></returns>
        public string xpflag { get; set; }
        /// <summary>
        /// ry_clxxz
        /// </summary>
        /// <returns></returns>
        public string ry_clxxz { get; set; }
        /// <summary>
        /// ry_ldzcz
        /// </summary>
        /// <returns></returns>
        public string ry_ldzcz { get; set; }
        /// <summary>
        /// ry_gz
        /// </summary>
        /// <returns></returns>
        public string ry_gz { get; set; }
        /// <summary>
        /// ry_zljcy
        /// </summary>
        /// <returns></returns>
        public string ry_zljcy { get; set; }
        /// <summary>
        /// ry_ysy
        /// </summary>
        /// <returns></returns>
        public string ry_ysy { get; set; }
        /// <summary>
        /// js
        /// </summary>
        /// <returns></returns>
        public string js { get; set; }
        /// <summary>
        /// hc_mprint
        /// </summary>
        /// <returns></returns>
        public string hc_mprint { get; set; }
        /// <summary>
        /// hc_bj
        /// </summary>
        /// <returns></returns>
        public string hc_bj { get; set; }
        /// <summary>
        /// hc_sj
        /// </summary>
        /// <returns></returns>
        public DateTime? hc_sj { get; set; }
        /// <summary>
        /// hc_bfbz
        /// </summary>
        /// <returns></returns>
        public string hc_bfbz { get; set; }
        /// <summary>
        /// r_jstep
        /// </summary>
        /// <returns></returns>
        public string r_jstep { get; set; }
        /// <summary>
        /// r_jstate
        /// </summary>
        /// <returns></returns>
        public string r_jstate { get; set; }
        /// <summary>
        /// r_jtime
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime { get; set; }
        /// <summary>
        /// r_jtime_1
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_1 { get; set; }
        /// <summary>
        /// r_jtime_2
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_2 { get; set; }
        /// <summary>
        /// r_jtime_3
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_3 { get; set; }
        /// <summary>
        /// r_jtime_4
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_4 { get; set; }
        /// <summary>
        /// r_jtime_5
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_5 { get; set; }
        /// <summary>
        /// r_jtime_6
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_6 { get; set; }
        /// <summary>
        /// r_jtime_7
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_7 { get; set; }
        /// <summary>
        /// r_jtime_8
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_8 { get; set; }
        /// <summary>
        /// r_jtime_9
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_9 { get; set; }
        /// <summary>
        /// r_jtime_10
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_10 { get; set; }
        /// <summary>
        /// r_jtime_1_1
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_1_1 { get; set; }
        /// <summary>
        /// r_jtime_2_1
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_2_1 { get; set; }
        /// <summary>
        /// r_jtime_3_1
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_3_1 { get; set; }
        /// <summary>
        /// r_jtime_4_1
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_4_1 { get; set; }
        /// <summary>
        /// r_jtime_5_1
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_5_1 { get; set; }
        /// <summary>
        /// r_jtime_6_1
        /// </summary>
        /// <returns></returns>
        public DateTime? r_jtime_6_1 { get; set; }
        /// <summary>
        /// r_createsj
        /// </summary>
        /// <returns></returns>
        public DateTime? r_createsj { get; set; }
        /// <summary>
        /// r_creatxm
        /// </summary>
        /// <returns></returns>
        public string r_creatxm { get; set; }
        /// <summary>
        /// r_sendbz
        /// </summary>
        /// <returns></returns>
        public string r_sendbz { get; set; }
        /// <summary>
        /// r_sendsj
        /// </summary>
        /// <returns></returns>
        public DateTime? r_sendsj { get; set; }
        /// <summary>
        /// r_sendxm
        /// </summary>
        /// <returns></returns>
        public string r_sendxm { get; set; }
        /// <summary>
        /// r_printbz
        /// </summary>
        /// <returns></returns>
        public string r_printbz { get; set; }
        /// <summary>
        /// r_printsj
        /// </summary>
        /// <returns></returns>
        public DateTime? r_printsj { get; set; }
        /// <summary>
        /// r_printxm
        /// </summary>
        /// <returns></returns>
        public string r_printxm { get; set; }
        #endregion
    }
}
