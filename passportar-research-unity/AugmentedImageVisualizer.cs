// Code from https://developers.google.com/ar/develop/c/augmented-images/
// Provided example code by Google ARcore. Modified for PassportAR Research purpose
//-----------------------------------------------------------------------
// <copyright file="AugmentedImageVisualizer.cs" company="Google">
//
// Copyright 2018 Google LLC. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Collections; //MR
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;

    public class AugmentedImageVisualizer : MonoBehaviour
    {

        public AugmentedImage Image;
        public GameObject FrameLowerLeft;
        public GameObject FrameLowerRight;
        public GameObject FrameUpperLeft;
        public GameObject FrameUpperRight;
        public GameObject Sphere; //MR
        public GameObject lowpoly_earth; //MR

        public GameObject PassportCoverPlane;//MR
        public Vector3 PassportPlaneVect;
        public Material earthtransp, AD_mat, AE_mat, AF_mat, AG_mat, AL_mat, AM_mat, AO_mat, AR_mat, AT_mat, AU_mat, AZ_mat, BA_mat, BB_mat, BD_mat, BE_mat, BF_mat, BG_mat, BH_mat, BI_mat, BJ_mat, BN_mat, BO_mat, BR_mat, BS_mat, BT_mat, BW_mat, BY_mat, BZ_mat, CA_mat, CD_mat, CF_mat, CG_mat, CH_mat, CI_mat, CL_mat, CM_mat, CN_mat, CO_mat, CR_mat, CU_mat, CV_mat, CY_mat, CZ_mat, DE_mat, DJ_mat, DK_mat, DM_mat, DO_mat, DZ_mat, EC_mat, EE_mat, EG_mat, ER_mat, ES_mat, ET_mat, FI_mat, FJ_mat, FM_mat, FR_mat, GA_mat, GB_mat, GD_mat, GE_mat, GH_mat, GM_mat, GN_mat, GQ_mat, GR_mat, GT_mat, GW_mat, GY_mat, HK_mat, HN_mat, HR_mat, HT_mat, HU_mat, ID_mat, IE_mat, IL_mat, IN_mat, IQ_mat, IR_mat, IS_mat, IT_mat, JM_mat, JO_mat, JP_mat, KE_mat, KG_mat, KH_mat, KI_mat, KM_mat, KN_mat, KP_mat, KR_mat, KW_mat, KZ_mat, LA_mat, LB_mat, LC_mat, LI_mat, LK_mat, LR_mat, LS_mat, LT_mat, LU_mat, LV_mat, LY_mat, MA_mat, MC_mat, MD_mat, ME_mat, MG_mat, MH_mat, MK_mat, ML_mat, MM_mat, MN_mat, MO_mat, MR_mat, MT_mat, MU_mat, MV_mat, MW_mat, MX_mat, MY_mat, MZ_mat, NA_mat, NE_mat, NG_mat, NI_mat, NL_mat, NO_mat, NP_mat, NR_mat, NZ_mat, OM_mat, PA_mat, PE_mat, PG_mat, PH_mat, PK_mat, PL_mat, PS_mat, PT_mat, PW_mat, PY_mat, QA_mat, RK_mat, RO_mat, RS_mat, RU_mat, RW_mat, SA_mat, SB_mat, SC_mat, SD_mat, SE_mat, SG_mat, SI_mat, SK_mat, SL_mat, SM_mat, SN_mat, SO_mat, SR_mat, SS_mat, ST_mat, SV_mat, SY_mat, SZ_mat, TD_mat, TG_mat, TH_mat, TJ_mat, TL_mat, TM_mat, TN_mat, TO_mat, TR_mat, TT_mat, TV_mat, TW_mat, TZ_mat, UA_mat, UG_mat, US_mat, UY_mat, UZ_mat, VA_mat, VC_mat, VE_mat, VN_mat, VU_mat, WS_mat, YE_mat, ZA_mat, ZM_mat, ZW_mat;

        public string nationality = "Nationality";
        public string receivedNationality;
        private NationalityTextController nationalityTextContr;
        private EarthMeshController EarthMeshContr;
        private PassportIdentDict passportIdentDictContr;
        private ChangeSceneOnCountryTouch CountryTouchContr;
        private MobilityIndexText MobilityIndexContr;
        private TextSwapContr TextSwapController;
        private string countryclicked = "EMPTY";
        private float timer = 0.0f;

        public void Awake()
        {
            nationalityTextContr = GameObject.FindObjectOfType<NationalityTextController>();
            EarthMeshContr = GameObject.FindObjectOfType<EarthMeshController>();
            passportIdentDictContr = GameObject.FindObjectOfType<PassportIdentDict>();
            CountryTouchContr = GameObject.FindObjectOfType<ChangeSceneOnCountryTouch>();
            MobilityIndexContr = GameObject.FindObjectOfType<MobilityIndexText>();
            TextSwapController = GameObject.FindObjectOfType<TextSwapContr>();
        }

        public void Update()
        {
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                FrameLowerLeft.SetActive(false);
                FrameLowerRight.SetActive(false);
                FrameUpperLeft.SetActive(false);
                FrameUpperRight.SetActive(false);
                Sphere.SetActive(false); //MR
                lowpoly_earth.SetActive(false); //MR
                PassportCoverPlane.SetActive(false);
                timer = 0.0f;
                return;
            }

            timer += Time.deltaTime;
            PlayerPrefs.SetFloat("ARTrackingTime", timer);
            PlayerPrefs.Save();

            float halfWidth = Image.ExtentX / 2;
            float halfHeight = Image.ExtentZ / 2;
            FrameLowerLeft.transform.localPosition =
                (halfWidth * Vector3.left) + (halfHeight * Vector3.back);
            FrameLowerRight.transform.localPosition =
                (halfWidth * Vector3.right) + (halfHeight * Vector3.back);
            FrameUpperLeft.transform.localPosition =
                (halfWidth * Vector3.left) + (halfHeight * Vector3.forward);
            FrameUpperRight.transform.localPosition =
                (halfWidth * Vector3.right) + (halfHeight * Vector3.forward);

            Sphere.transform.localPosition =
                 (halfWidth * Vector3.left) + (halfHeight * Vector3.back); //MR

            PassportCoverPlane.transform.localPosition =
               (Image.ExtentX * Vector3.zero) + (Image.ExtentZ * Vector3.zero);
            PassportCoverPlane.transform.localRotation = Quaternion.Euler(0, 180, 0);

            float passportlength = Vector3.Distance(FrameLowerLeft.transform.localPosition, FrameUpperLeft.transform.localPosition);
            float passportwidth = Vector3.Distance(FrameLowerLeft.transform.localPosition, FrameLowerRight.transform.localPosition);

            //Debug.Log("PassportLength is " + passportlength + " passportwidth is " + passportwidth);

            countryclicked = CountryTouchContr.catchClickedCountry();

            var planematerial = PassportCoverPlane.GetComponent<MeshRenderer>(); //Assign material to overlay plane
            if (countryclicked == "AND") { planematerial.material = AD_mat; }
            if (countryclicked == "ARE") { planematerial.material = AE_mat; }
            if (countryclicked == "AFG") { planematerial.material = AF_mat; }
            if (countryclicked == "ATG") { planematerial.material = AG_mat; }
            if (countryclicked == "ALB") { planematerial.material = AL_mat; }
            if (countryclicked == "ARM") { planematerial.material = AM_mat; }
            if (countryclicked == "AGO") { planematerial.material = AO_mat; }
            if (countryclicked == "ARG") { planematerial.material = AR_mat; }
            if (countryclicked == "AUT") { planematerial.material = AT_mat; }
            if (countryclicked == "AUS") { planematerial.material = AU_mat; }
            if (countryclicked == "AZE") { planematerial.material = AZ_mat; }
            if (countryclicked == "BIH") { planematerial.material = BA_mat; }
            if (countryclicked == "BRB") { planematerial.material = BB_mat; }
            if (countryclicked == "BGD") { planematerial.material = BD_mat; }
            if (countryclicked == "BEL") { planematerial.material = BE_mat; }
            if (countryclicked == "BFA") { planematerial.material = BF_mat; }
            if (countryclicked == "BGR") { planematerial.material = BG_mat; }
            if (countryclicked == "BHR") { planematerial.material = BH_mat; }
            if (countryclicked == "BDI") { planematerial.material = BI_mat; }
            if (countryclicked == "BEN") { planematerial.material = BJ_mat; }
            if (countryclicked == "BRN") { planematerial.material = BN_mat; }
            if (countryclicked == "BOL") { planematerial.material = BO_mat; }
            if (countryclicked == "BRA") { planematerial.material = BR_mat; }
            if (countryclicked == "BHS") { planematerial.material = BS_mat; }
            if (countryclicked == "BTN") { planematerial.material = BT_mat; }
            if (countryclicked == "BWA") { planematerial.material = BW_mat; }
            if (countryclicked == "BLR") { planematerial.material = BY_mat; }
            if (countryclicked == "BLZ") { planematerial.material = BZ_mat; }
            if (countryclicked == "CAN") { planematerial.material = CA_mat; }
            if (countryclicked == "COD") { planematerial.material = CD_mat; }
            if (countryclicked == "CAF") { planematerial.material = CF_mat; }
            if (countryclicked == "COG") { planematerial.material = CG_mat; }
            if (countryclicked == "CHE") { planematerial.material = CH_mat; }
            if (countryclicked == "CIV") { planematerial.material = CI_mat; }
            if (countryclicked == "CHL") { planematerial.material = CL_mat; }
            if (countryclicked == "CMR") { planematerial.material = CM_mat; }
            if (countryclicked == "CHN") { planematerial.material = CN_mat; }
            if (countryclicked == "COL") { planematerial.material = CO_mat; }
            if (countryclicked == "CRI") { planematerial.material = CR_mat; }
            if (countryclicked == "CUB") { planematerial.material = CU_mat; }
            if (countryclicked == "CPV") { planematerial.material = CV_mat; }
            if (countryclicked == "CYP") { planematerial.material = CY_mat; }
            if (countryclicked == "CZE") { planematerial.material = CZ_mat; }
            if (countryclicked == "DEU") { planematerial.material = DE_mat; }
            if (countryclicked == "DJI") { planematerial.material = DJ_mat; }
            if (countryclicked == "DNK") { planematerial.material = DK_mat; }
            if (countryclicked == "DMA") { planematerial.material = DM_mat; }
            if (countryclicked == "DOM") { planematerial.material = DO_mat; }
            if (countryclicked == "DZA") { planematerial.material = DZ_mat; }
            if (countryclicked == "ECU") { planematerial.material = EC_mat; }
            if (countryclicked == "EST") { planematerial.material = EE_mat; }
            if (countryclicked == "EGY") { planematerial.material = EG_mat; }
            if (countryclicked == "ERI") { planematerial.material = ER_mat; }
            if (countryclicked == "ESP") { planematerial.material = ES_mat; }
            if (countryclicked == "ETH") { planematerial.material = ET_mat; }
            if (countryclicked == "FIN") { planematerial.material = FI_mat; }
            if (countryclicked == "FJI") { planematerial.material = FJ_mat; }
            if (countryclicked == "FSM") { planematerial.material = FM_mat; }
            if (countryclicked == "FRA") { planematerial.material = FR_mat; }
            if (countryclicked == "GAB") { planematerial.material = GA_mat; }
            if (countryclicked == "GBR") { planematerial.material = GB_mat; }
            if (countryclicked == "GRD") { planematerial.material = GD_mat; }
            if (countryclicked == "GEO") { planematerial.material = GE_mat; }
            if (countryclicked == "GHA") { planematerial.material = GH_mat; }
            if (countryclicked == "GMB") { planematerial.material = GM_mat; }
            if (countryclicked == "GIN") { planematerial.material = GN_mat; }
            if (countryclicked == "GNQ") { planematerial.material = GQ_mat; }
            if (countryclicked == "GRC") { planematerial.material = GR_mat; }
            if (countryclicked == "GTM") { planematerial.material = GT_mat; }
            if (countryclicked == "GNB") { planematerial.material = GW_mat; }
            if (countryclicked == "GUY") { planematerial.material = GY_mat; }
            if (countryclicked == "HKG") { planematerial.material = HK_mat; }
            if (countryclicked == "HND") { planematerial.material = HN_mat; }
            if (countryclicked == "HRV") { planematerial.material = HR_mat; }
            if (countryclicked == "HTI") { planematerial.material = HT_mat; }
            if (countryclicked == "HUN") { planematerial.material = HU_mat; }
            if (countryclicked == "IDN") { planematerial.material = ID_mat; }
            if (countryclicked == "IRL") { planematerial.material = IE_mat; }
            if (countryclicked == "ISR") { planematerial.material = IL_mat; }
            if (countryclicked == "IND") { planematerial.material = IN_mat; }
            if (countryclicked == "IRQ") { planematerial.material = IQ_mat; }
            if (countryclicked == "IRN") { planematerial.material = IR_mat; }
            if (countryclicked == "ISL") { planematerial.material = IS_mat; }
            if (countryclicked == "ITA") { planematerial.material = IT_mat; }
            if (countryclicked == "JAM") { planematerial.material = JM_mat; }
            if (countryclicked == "JOR") { planematerial.material = JO_mat; }
            if (countryclicked == "JPN") { planematerial.material = JP_mat; }
            if (countryclicked == "KEN") { planematerial.material = KE_mat; }
            if (countryclicked == "KGZ") { planematerial.material = KG_mat; }
            if (countryclicked == "KHM") { planematerial.material = KH_mat; }
            if (countryclicked == "KIR") { planematerial.material = KI_mat; }
            if (countryclicked == "COM") { planematerial.material = KM_mat; }
            if (countryclicked == "KNA") { planematerial.material = KN_mat; }
            if (countryclicked == "PRK") { planematerial.material = KP_mat; }
            if (countryclicked == "KOR") { planematerial.material = KR_mat; }
            if (countryclicked == "KWT") { planematerial.material = KW_mat; }
            if (countryclicked == "KAZ") { planematerial.material = KZ_mat; }
            if (countryclicked == "LAO") { planematerial.material = LA_mat; }
            if (countryclicked == "LBN") { planematerial.material = LB_mat; }
            if (countryclicked == "LCA") { planematerial.material = LC_mat; }
            if (countryclicked == "LIE") { planematerial.material = LI_mat; }
            if (countryclicked == "LKA") { planematerial.material = LK_mat; }
            if (countryclicked == "LBR") { planematerial.material = LR_mat; }
            if (countryclicked == "LSO") { planematerial.material = LS_mat; }
            if (countryclicked == "LTU") { planematerial.material = LT_mat; }
            if (countryclicked == "LUX") { planematerial.material = LU_mat; }
            if (countryclicked == "LVA") { planematerial.material = LV_mat; }
            if (countryclicked == "LBY") { planematerial.material = LY_mat; }
            if (countryclicked == "MAR") { planematerial.material = MA_mat; }
            if (countryclicked == "MCO") { planematerial.material = MC_mat; }
            if (countryclicked == "MDA") { planematerial.material = MD_mat; }
            if (countryclicked == "MNE") { planematerial.material = ME_mat; }
            if (countryclicked == "MDG") { planematerial.material = MG_mat; }
            if (countryclicked == "MHL") { planematerial.material = MH_mat; }
            if (countryclicked == "MKD") { planematerial.material = MK_mat; }
            if (countryclicked == "MLI") { planematerial.material = ML_mat; }
            if (countryclicked == "MMR") { planematerial.material = MM_mat; }
            if (countryclicked == "MNG") { planematerial.material = MN_mat; }
            if (countryclicked == "MAC") { planematerial.material = MO_mat; }
            if (countryclicked == "MRT") { planematerial.material = MR_mat; }
            if (countryclicked == "MLT") { planematerial.material = MT_mat; }
            if (countryclicked == "MUS") { planematerial.material = MU_mat; }
            if (countryclicked == "MDV") { planematerial.material = MV_mat; }
            if (countryclicked == "MWI") { planematerial.material = MW_mat; }
            if (countryclicked == "MEX") { planematerial.material = MX_mat; }
            if (countryclicked == "MYS") { planematerial.material = MY_mat; }
            if (countryclicked == "MOZ") { planematerial.material = MZ_mat; }
            if (countryclicked == "NAM") { planematerial.material = NA_mat; }
            if (countryclicked == "NER") { planematerial.material = NE_mat; }
            if (countryclicked == "NGA") { planematerial.material = NG_mat; }
            if (countryclicked == "NIC") { planematerial.material = NI_mat; }
            if (countryclicked == "NLD") { planematerial.material = NL_mat; }
            if (countryclicked == "NOR") { planematerial.material = NO_mat; }
            if (countryclicked == "NPL") { planematerial.material = NP_mat; }
            if (countryclicked == "NRU") { planematerial.material = NR_mat; }
            if (countryclicked == "NZL") { planematerial.material = NZ_mat; }
            if (countryclicked == "OMN") { planematerial.material = OM_mat; }
            if (countryclicked == "PAN") { planematerial.material = PA_mat; }
            if (countryclicked == "PER") { planematerial.material = PE_mat; }
            if (countryclicked == "PNG") { planematerial.material = PG_mat; }
            if (countryclicked == "PHL") { planematerial.material = PH_mat; }
            if (countryclicked == "PAK") { planematerial.material = PK_mat; }
            if (countryclicked == "POL") { planematerial.material = PL_mat; }
            if (countryclicked == "PSE") { planematerial.material = PS_mat; }
            if (countryclicked == "PRT") { planematerial.material = PT_mat; }
            if (countryclicked == "PLW") { planematerial.material = PW_mat; }
            if (countryclicked == "PRY") { planematerial.material = PY_mat; }
            if (countryclicked == "QAT") { planematerial.material = QA_mat; }
            if (countryclicked == "KOS") { planematerial.material = RK_mat; }
            if (countryclicked == "ROU") { planematerial.material = RO_mat; }
            if (countryclicked == "SRB") { planematerial.material = RS_mat; }
            if (countryclicked == "RUS") { planematerial.material = RU_mat; }
            if (countryclicked == "RWA") { planematerial.material = RW_mat; }
            if (countryclicked == "SAU") { planematerial.material = SA_mat; }
            if (countryclicked == "SLB") { planematerial.material = SB_mat; }
            if (countryclicked == "SYC") { planematerial.material = SC_mat; }
            if (countryclicked == "SDN") { planematerial.material = SD_mat; }
            if (countryclicked == "SWE") { planematerial.material = SE_mat; }
            if (countryclicked == "SGP") { planematerial.material = SG_mat; }
            if (countryclicked == "SVN") { planematerial.material = SI_mat; }
            if (countryclicked == "SVK") { planematerial.material = SK_mat; }
            if (countryclicked == "SLE") { planematerial.material = SL_mat; }
            if (countryclicked == "SMR") { planematerial.material = SM_mat; }
            if (countryclicked == "SEN") { planematerial.material = SN_mat; }
            if (countryclicked == "SOM") { planematerial.material = SO_mat; }
            if (countryclicked == "SUR") { planematerial.material = SR_mat; }
            if (countryclicked == "SSD") { planematerial.material = SS_mat; }
            if (countryclicked == "STP") { planematerial.material = ST_mat; }
            if (countryclicked == "SLV") { planematerial.material = SV_mat; }
            if (countryclicked == "SYR") { planematerial.material = SY_mat; }
            if (countryclicked == "SWZ") { planematerial.material = SZ_mat; }
            if (countryclicked == "TCD") { planematerial.material = TD_mat; }
            if (countryclicked == "TGO") { planematerial.material = TG_mat; }
            if (countryclicked == "THA") { planematerial.material = TH_mat; }
            if (countryclicked == "TJK") { planematerial.material = TJ_mat; }
            if (countryclicked == "TLS") { planematerial.material = TL_mat; }
            if (countryclicked == "TKM") { planematerial.material = TM_mat; }
            if (countryclicked == "TUN") { planematerial.material = TN_mat; }
            if (countryclicked == "TON") { planematerial.material = TO_mat; }
            if (countryclicked == "TUR") { planematerial.material = TR_mat; }
            if (countryclicked == "TTO") { planematerial.material = TT_mat; }
            if (countryclicked == "TUV") { planematerial.material = TV_mat; }
            if (countryclicked == "TWN") { planematerial.material = TW_mat; }
            if (countryclicked == "TZA") { planematerial.material = TZ_mat; }
            if (countryclicked == "UKR") { planematerial.material = UA_mat; }
            if (countryclicked == "UGA") { planematerial.material = UG_mat; }
            if (countryclicked == "USA") { planematerial.material = US_mat; }
            if (countryclicked == "URY") { planematerial.material = UY_mat; }
            if (countryclicked == "UZB") { planematerial.material = UZ_mat; }
            if (countryclicked == "VAT") { planematerial.material = VA_mat; }
            if (countryclicked == "VCT") { planematerial.material = VC_mat; }
            if (countryclicked == "VEN") { planematerial.material = VE_mat; }
            if (countryclicked == "VNM") { planematerial.material = VN_mat; }
            if (countryclicked == "VUT") { planematerial.material = VU_mat; }
            if (countryclicked == "WSM") { planematerial.material = WS_mat; }
            if (countryclicked == "YEM") { planematerial.material = YE_mat; }
            if (countryclicked == "ZAF") { planematerial.material = ZA_mat; }
            if (countryclicked == "ZMB") { planematerial.material = ZM_mat; }
            if (countryclicked == "ZWE") { planematerial.material = ZW_mat; }
            if (countryclicked == "EARTH_MESH" || countryclicked == "EARTH_MESH_map" || countryclicked == "lowpoly_earth") { planematerial.material = earthtransp; }
           
            FrameLowerLeft.SetActive(true); //Make frame visible
            FrameLowerRight.SetActive(true);
            FrameUpperLeft.SetActive(true);
            FrameUpperRight.SetActive(true);
            Sphere.SetActive(true); //MR
            lowpoly_earth.SetActive(true); //Make globe visible

            if (countryclicked != "EMPTY") //If clicked on a country, not globe, make other passport cover visible
            {
                PassportCoverPlane.SetActive(true);
            } else
            {
                PassportCoverPlane.SetActive(false);
            }

            nationalityTextContr.catchNationalityInt(Image.DatabaseIndex); //Sends the current passport int to different scripts
            EarthMeshContr.catchDetectedPassportToEarthMeshController(Image.DatabaseIndex);
            MobilityIndexContr.catchNationalityInt(Image.DatabaseIndex);
            TextSwapController.catchNationalityIntFromViz(Image.DatabaseIndex);
        }
    }
}
