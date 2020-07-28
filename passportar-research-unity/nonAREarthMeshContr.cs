using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonAREarthMeshContr : MonoBehaviour
{
    public GameObject EARTH_MESH, AFG, ALB, DZA, AND, AGO, ATG, ARG, ARM, AUS, AUT, AZE, BHS, BHR, BGD, BRB, BLR, BEL, BLZ, BEN, BTN, BOL, BIH, BWA, BRA, BRN, BGR, BFA, BDI, KHM, CMR, CAN, CPV, CAF, TCD, CHL, CHN, COL, COM, COG, COD, CRI, CIV, HRV, CUB, CYP, CZE, DNK, DJI, DMA, DOM, ECU, EGY, SLV, GNQ, ERI, EST, ETH, FJI, FIN, FRA, GAB, GMB, GEO, DEU, GHA, GRC, GRD, GTM, GIN, GNB, GUY, HTI, VAT, HND, HKG, HUN, ISL, IND, IDN, IRN, IRQ, IRL, ISR, ITA, JAM, JPN, JOR, KAZ, KEN, KIR, PRK, KOR, KOS, KWT, KGZ, LAO, LVA, LBN, LSO, LBR, LBY, LIE, LTU, LUX, MAC, MDG, MWI, MYS, MDV, MLI, MLT, MHL, MRT, MUS, MEX, FSM, MDA, MCO, MNG, MNE, MAR, MOZ, MMR, NAM, NRU, NPL, NLD, NZL, NIC, NER, NGA, MKD, NOR, OMN, PAK, PLW, PSE, PAN, PNG, PRY, PER, PHL, POL, PRT, QAT, ROU, RUS, RWA, KNA, LCA, VCT, WSM, SMR, STP, SAU, SEN, SRB, SYC, SLE, SGP, SVK, SVN, SLB, SOM, ZAF, SSD, ESP, LKA, SDN, SUR, SWZ, SWE, CHE, SYR, TWN, TJK, TZA, THA, TLS, TGO, TON, TTO, TUN, TUR, TKM, TUV, UGA, UKR, ARE, GBR, USA, URY, UZB, VUT, VEN, VNM, YEM, ZMB, ZWE;
    public GameObject CHN2, DNK2, MYS2, GBR2, GRC2, JPN2, IND2, IND3, IND4, IND5, IND6, IND7, PHL2, AUS2, CAN2, NZL2, USA2, USA3; //Subdivisions from countries

    public string currentNationality = "EMPTY";
    public int currentNationalityInt;
    public int currentOccludNatInt = 999;
    private bool stopFlag = false;
    private bool stopFlagClicked = false;
    private LoadPassportData LoadPassportDataContr;
    private ChangeSceneOnCountryTouch CountryTouchContr;
    private PassportIdentDict passportIdentDictContr;
    public Dictionary<string, Color32> colorCountriesDict = new Dictionary<string, Color32>(); //used at all?

    public List<int> receivedPassportDataList = new List<int>();
    public List<int> receivedOccPassportDataList = new List<int>();
    public List<string> receivedCountryIDList = new List<string>();
    public List<string> visaReqCountries = new List<string>();
    public List<string> visaECountries = new List<string>();
    public List<string> visaOnArrCountries = new List<string>();
    public List<string> visaFreeCountries = new List<string>();
    public string visaItselfIdentified;
    private string playerNationalityfromForm;

    Color32 visaReq1color = new Color32(255, 104, 110, 100); //Visa required; int = 1; redish color
    Color32 visaE2color = new Color32(255, 184, 64, 100); //E-Visa or Preenrollment; int = 2; orange color
    Color32 visaOnArr3color = new Color32(242, 245, 134, 100); //Visa on arrival; int = 3; yellow color
    Color32 visaFree4color = new Color32(110, 255, 104, 100); //Visa free; int = 4; green color
    Color32 visaItselfcolor = new Color32(255, 255, 255, 100); //Country itself, int = 5; 
    Color32 DefaultColor = new Color32(0, 0, 0, 100); //Black
    Color32 WhiteColor = new Color32(255, 255, 255, 100); //White
    Color32 AFG_color, ALB_color, DZA_color, AND_color, AGO_color, ATG_color, ARG_color, ARM_color, AUS_color, AUT_color, AZE_color, BHS_color, BHR_color, BGD_color, BRB_color, BLR_color, BEL_color, BLZ_color, BEN_color, BTN_color, BOL_color, BIH_color, BWA_color, BRA_color, BRN_color, BGR_color, BFA_color, BDI_color, KHM_color, CMR_color, CAN_color, CPV_color, CAF_color, TCD_color, CHL_color, CHN_color, COL_color, COM_color, COG_color, COD_color, CRI_color, CIV_color, HRV_color, CUB_color, CYP_color, CZE_color, DNK_color, DJI_color, DMA_color, DOM_color, ECU_color, EGY_color, SLV_color, GNQ_color, ERI_color, EST_color, ETH_color, FJI_color, FIN_color, FRA_color, GAB_color, GMB_color, GEO_color, DEU_color, GHA_color, GRC_color, GRD_color, GTM_color, GIN_color, GNB_color, GUY_color, HTI_color, VAT_color, HND_color, HKG_color, HUN_color, ISL_color, IND_color, IDN_color, IRN_color, IRQ_color, IRL_color, ISR_color, ITA_color, JAM_color, JPN_color, JOR_color, KAZ_color, KEN_color, KIR_color, PRK_color, KOR_color, KOS_color, KWT_color, KGZ_color, LAO_color, LVA_color, LBN_color, LSO_color, LBR_color, LBY_color, LIE_color, LTU_color, LUX_color, MAC_color, MDG_color, MWI_color, MYS_color, MDV_color, MLI_color, MLT_color, MHL_color, MRT_color, MUS_color, MEX_color, FSM_color, MDA_color, MCO_color, MNG_color, MNE_color, MAR_color, MOZ_color, MMR_color, NAM_color, NRU_color, NPL_color, NLD_color, NZL_color, NIC_color, NER_color, NGA_color, MKD_color, NOR_color, OMN_color, PAK_color, PLW_color, PSE_color, PAN_color, PNG_color, PRY_color, PER_color, PHL_color, POL_color, PRT_color, QAT_color, ROU_color, RUS_color, RWA_color, KNA_color, LCA_color, VCT_color, WSM_color, SMR_color, STP_color, SAU_color, SEN_color, SRB_color, SYC_color, SLE_color, SGP_color, SVK_color, SVN_color, SLB_color, SOM_color, ZAF_color, SSD_color, ESP_color, LKA_color, SDN_color, SUR_color, SWZ_color, SWE_color, CHE_color, SYR_color, TWN_color, TJK_color, TZA_color, THA_color, TLS_color, TGO_color, TON_color, TTO_color, TUN_color, TUR_color, TKM_color, TUV_color, UGA_color, UKR_color, ARE_color, GBR_color, USA_color, URY_color, UZB_color, VUT_color, VEN_color, VNM_color, YEM_color, ZMB_color, ZWE_color;

    Renderer rend; //concept from https://www.youtube.com/watch?v=5OxmXaeAx2g
    Renderer AFG_rend, ALB_rend, DZA_rend, AND_rend, AGO_rend, ATG_rend, ARG_rend, ARM_rend, AUS_rend, AUT_rend, AZE_rend, BHS_rend, BHR_rend, BGD_rend, BRB_rend, BLR_rend, BEL_rend, BLZ_rend, BEN_rend, BTN_rend, BOL_rend, BIH_rend, BWA_rend, BRA_rend, BRN_rend, BGR_rend, BFA_rend, BDI_rend, KHM_rend, CMR_rend, CAN_rend, CPV_rend, CAF_rend, TCD_rend, CHL_rend, CHN_rend, COL_rend, COM_rend, COG_rend, COD_rend, CRI_rend, CIV_rend, HRV_rend, CUB_rend, CYP_rend, CZE_rend, DNK_rend, DJI_rend, DMA_rend, DOM_rend, ECU_rend, EGY_rend, SLV_rend, GNQ_rend, ERI_rend, EST_rend, ETH_rend, FJI_rend, FIN_rend, FRA_rend, GAB_rend, GMB_rend, GEO_rend, DEU_rend, GHA_rend, GRC_rend, GRD_rend, GTM_rend, GIN_rend, GNB_rend, GUY_rend, HTI_rend, VAT_rend, HND_rend, HKG_rend, HUN_rend, ISL_rend, IND_rend, IDN_rend, IRN_rend, IRQ_rend, IRL_rend, ISR_rend, ITA_rend, JAM_rend, JPN_rend, JOR_rend, KAZ_rend, KEN_rend, KIR_rend, PRK_rend, KOR_rend, KOS_rend, KWT_rend, KGZ_rend, LAO_rend, LVA_rend, LBN_rend, LSO_rend, LBR_rend, LBY_rend, LIE_rend, LTU_rend, LUX_rend, MAC_rend, MDG_rend, MWI_rend, MYS_rend, MDV_rend, MLI_rend, MLT_rend, MHL_rend, MRT_rend, MUS_rend, MEX_rend, FSM_rend, MDA_rend, MCO_rend, MNG_rend, MNE_rend, MAR_rend, MOZ_rend, MMR_rend, NAM_rend, NRU_rend, NPL_rend, NLD_rend, NZL_rend, NIC_rend, NER_rend, NGA_rend, MKD_rend, NOR_rend, OMN_rend, PAK_rend, PLW_rend, PSE_rend, PAN_rend, PNG_rend, PRY_rend, PER_rend, PHL_rend, POL_rend, PRT_rend, QAT_rend, ROU_rend, RUS_rend, RWA_rend, KNA_rend, LCA_rend, VCT_rend, WSM_rend, SMR_rend, STP_rend, SAU_rend, SEN_rend, SRB_rend, SYC_rend, SLE_rend, SGP_rend, SVK_rend, SVN_rend, SLB_rend, SOM_rend, ZAF_rend, SSD_rend, ESP_rend, LKA_rend, SDN_rend, SUR_rend, SWZ_rend, SWE_rend, CHE_rend, SYR_rend, TWN_rend, TJK_rend, TZA_rend, THA_rend, TLS_rend, TGO_rend, TON_rend, TTO_rend, TUN_rend, TUR_rend, TKM_rend, TUV_rend, UGA_rend, UKR_rend, ARE_rend, GBR_rend, USA_rend, URY_rend, UZB_rend, VUT_rend, VEN_rend, VNM_rend, YEM_rend, ZMB_rend, ZWE_rend;
    Renderer CHN2_rend, DNK2_rend, MYS2_rend, GBR2_rend, GRC2_rend, JPN2_rend, IND2_rend, IND3_rend, IND4_rend, IND5_rend, IND6_rend, IND7_rend, PHL2_rend, AUS2_rend, CAN2_rend, NZL2_rend, USA2_rend, USA3_rend;

    public void Awake()
    {
        LoadPassportDataContr = GameObject.FindObjectOfType<LoadPassportData>();
        CountryTouchContr = GameObject.FindObjectOfType<ChangeSceneOnCountryTouch>();
        passportIdentDictContr = GameObject.FindObjectOfType<PassportIdentDict>();
    }

    void Start()
    {
        getRenderers();
        setDefaultColor();
    }

    public void catchDetectedPassportToEarthMeshController(int nationality)
    {
        currentNationalityInt = nationality;
    }

    private void receiveDatafromPassportReader()
    {

        playerNationalityfromForm = PlayerPrefs.GetString("PreQ5Ans");
        setPreQcountry();
        receivedPassportDataList = LoadPassportDataContr.sendData(currentNationalityInt);
        receivedCountryIDList = LoadPassportDataContr.sendCountryList();

        for (int i = 0; i < receivedPassportDataList.Count; i++)
        {
            if (receivedCountryIDList[i] == "DONE")
            {
                execute();
            }
        }
    }

    private void Update()
    {
        while (!stopFlag)
        {
            receiveDatafromPassportReader();
            stopFlag = true;
        }
        UpdateCountriesOnTouchRequest();
    }

    private void UpdateCountriesOnTouchRequest()
    {
        receivedPassportDataList.Clear();
        visaFreeCountries.Clear();
        visaOnArrCountries.Clear();
        visaECountries.Clear();
        visaReqCountries.Clear();
        visaItselfIdentified = "EMPTY"; //

        if (Input.GetMouseButtonDown(0) && PlayerPrefs.GetInt("NonARPanelClosed") == 1)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit touchInformation;
            if (Physics.Raycast(ray, out touchInformation))
            {
                var rig = touchInformation.collider.GetComponent<MeshRenderer>();
                if (rig != null)
                {
                    currentNationality = touchInformation.collider.gameObject.name;
                }
            }
        }

        if (currentNationality == "AND") { currentOccludNatInt = 1; }
        if (currentNationality == "ARE") { currentOccludNatInt = 2; }
        if (currentNationality == "AFG") { currentOccludNatInt = 3; }
        if (currentNationality == "ATG") { currentOccludNatInt = 4; }
        if (currentNationality == "ALB") { currentOccludNatInt = 5; }
        if (currentNationality == "ARM") { currentOccludNatInt = 6; }
        if (currentNationality == "AGO") { currentOccludNatInt = 7; }
        if (currentNationality == "ARG") { currentOccludNatInt = 8; }
        if (currentNationality == "AUT") { currentOccludNatInt = 9; }
        if (currentNationality == "AUS") { currentOccludNatInt = 10; }
        if (currentNationality == "AZE") { currentOccludNatInt = 11; }
        if (currentNationality == "BIH") { currentOccludNatInt = 12; }
        if (currentNationality == "BRB") { currentOccludNatInt = 13; }
        if (currentNationality == "BGD") { currentOccludNatInt = 14; }
        if (currentNationality == "BEL") { currentOccludNatInt = 15; }
        if (currentNationality == "BFA") { currentOccludNatInt = 16; }
        if (currentNationality == "BGR") { currentOccludNatInt = 17; }
        if (currentNationality == "BHR") { currentOccludNatInt = 18; }
        if (currentNationality == "BDI") { currentOccludNatInt = 19; }
        if (currentNationality == "BEN") { currentOccludNatInt = 20; }
        if (currentNationality == "BRN") { currentOccludNatInt = 21; }
        if (currentNationality == "BOL") { currentOccludNatInt = 22; }
        if (currentNationality == "BRA") { currentOccludNatInt = 23; }
        if (currentNationality == "BHS") { currentOccludNatInt = 24; }
        if (currentNationality == "BTN") { currentOccludNatInt = 25; }
        if (currentNationality == "BWA") { currentOccludNatInt = 26; }
        if (currentNationality == "BLR") { currentOccludNatInt = 27; }
        if (currentNationality == "BLZ") { currentOccludNatInt = 28; }
        if (currentNationality == "CAN") { currentOccludNatInt = 29; }
        if (currentNationality == "COD") { currentOccludNatInt = 30; }
        if (currentNationality == "CAF") { currentOccludNatInt = 31; }
        if (currentNationality == "COG") { currentOccludNatInt = 32; }
        if (currentNationality == "CHE") { currentOccludNatInt = 33; }
        if (currentNationality == "CIV") { currentOccludNatInt = 34; }
        if (currentNationality == "CHL") { currentOccludNatInt = 35; }
        if (currentNationality == "CMR") { currentOccludNatInt = 36; }
        if (currentNationality == "CHN") { currentOccludNatInt = 37; }
        if (currentNationality == "COL") { currentOccludNatInt = 38; }
        if (currentNationality == "CRI") { currentOccludNatInt = 39; }
        if (currentNationality == "CUB") { currentOccludNatInt = 40; }
        if (currentNationality == "CPV") { currentOccludNatInt = 41; }
        if (currentNationality == "CYP") { currentOccludNatInt = 42; }
        if (currentNationality == "CZE") { currentOccludNatInt = 43; }
        if (currentNationality == "DEU") { currentOccludNatInt = 44; }
        if (currentNationality == "DJI") { currentOccludNatInt = 45; }
        if (currentNationality == "DNK") { currentOccludNatInt = 46; }
        if (currentNationality == "DMA") { currentOccludNatInt = 47; }
        if (currentNationality == "DOM") { currentOccludNatInt = 48; }
        if (currentNationality == "DZA") { currentOccludNatInt = 49; }
        if (currentNationality == "ECU") { currentOccludNatInt = 50; }
        if (currentNationality == "EST") { currentOccludNatInt = 51; }
        if (currentNationality == "EGY") { currentOccludNatInt = 52; }
        if (currentNationality == "ERI") { currentOccludNatInt = 53; }
        if (currentNationality == "ESP") { currentOccludNatInt = 54; }
        if (currentNationality == "ETH") { currentOccludNatInt = 55; }
        if (currentNationality == "FIN") { currentOccludNatInt = 56; }
        if (currentNationality == "FJI") { currentOccludNatInt = 57; }
        if (currentNationality == "FSM") { currentOccludNatInt = 58; }
        if (currentNationality == "FRA") { currentOccludNatInt = 59; }
        if (currentNationality == "GAB") { currentOccludNatInt = 60; }
        if (currentNationality == "GBR") { currentOccludNatInt = 61; }
        if (currentNationality == "GRD") { currentOccludNatInt = 62; }
        if (currentNationality == "GEO") { currentOccludNatInt = 63; }
        if (currentNationality == "GHA") { currentOccludNatInt = 64; }
        if (currentNationality == "GMB") { currentOccludNatInt = 65; }
        if (currentNationality == "GIN") { currentOccludNatInt = 66; }
        if (currentNationality == "GNQ") { currentOccludNatInt = 67; }
        if (currentNationality == "GRC") { currentOccludNatInt = 68; }
        if (currentNationality == "GTM") { currentOccludNatInt = 69; }
        if (currentNationality == "GNB") { currentOccludNatInt = 70; }
        if (currentNationality == "GUY") { currentOccludNatInt = 71; }
        if (currentNationality == "HKG") { currentOccludNatInt = 72; }
        if (currentNationality == "HND") { currentOccludNatInt = 73; }
        if (currentNationality == "HRV") { currentOccludNatInt = 74; }
        if (currentNationality == "HTI") { currentOccludNatInt = 75; }
        if (currentNationality == "HUN") { currentOccludNatInt = 76; }
        if (currentNationality == "IDN") { currentOccludNatInt = 77; }
        if (currentNationality == "IRL") { currentOccludNatInt = 78; }
        if (currentNationality == "ISR") { currentOccludNatInt = 79; }
        if (currentNationality == "IND") { currentOccludNatInt = 80; }
        if (currentNationality == "IRQ") { currentOccludNatInt = 81; }
        if (currentNationality == "IRN") { currentOccludNatInt = 82; }
        if (currentNationality == "ISL") { currentOccludNatInt = 83; }
        if (currentNationality == "ITA") { currentOccludNatInt = 84; }
        if (currentNationality == "JAM") { currentOccludNatInt = 85; }
        if (currentNationality == "JOR") { currentOccludNatInt = 86; }
        if (currentNationality == "JPN") { currentOccludNatInt = 87; }
        if (currentNationality == "KEN") { currentOccludNatInt = 88; }
        if (currentNationality == "KGZ") { currentOccludNatInt = 89; }
        if (currentNationality == "KHM") { currentOccludNatInt = 90; }
        if (currentNationality == "KIR") { currentOccludNatInt = 91; }
        if (currentNationality == "COM") { currentOccludNatInt = 92; }
        if (currentNationality == "KNA") { currentOccludNatInt = 93; }
        if (currentNationality == "PRK") { currentOccludNatInt = 94; }
        if (currentNationality == "KOR") { currentOccludNatInt = 95; }
        if (currentNationality == "KWT") { currentOccludNatInt = 96; }
        if (currentNationality == "KAZ") { currentOccludNatInt = 97; }
        if (currentNationality == "LAO") { currentOccludNatInt = 98; }
        if (currentNationality == "LBN") { currentOccludNatInt = 99; }
        if (currentNationality == "LCA") { currentOccludNatInt = 100; }
        if (currentNationality == "LIE") { currentOccludNatInt = 101; }
        if (currentNationality == "LKA") { currentOccludNatInt = 102; }
        if (currentNationality == "LBR") { currentOccludNatInt = 103; }
        if (currentNationality == "LSO") { currentOccludNatInt = 104; }
        if (currentNationality == "LTU") { currentOccludNatInt = 105; }
        if (currentNationality == "LUX") { currentOccludNatInt = 106; }
        if (currentNationality == "LVA") { currentOccludNatInt = 107; }
        if (currentNationality == "LBY") { currentOccludNatInt = 108; }
        if (currentNationality == "MAR") { currentOccludNatInt = 109; }
        if (currentNationality == "MCO") { currentOccludNatInt = 110; }
        if (currentNationality == "MDA") { currentOccludNatInt = 111; }
        if (currentNationality == "MNE") { currentOccludNatInt = 112; }
        if (currentNationality == "MDG") { currentOccludNatInt = 113; }
        if (currentNationality == "MHL") { currentOccludNatInt = 114; }
        if (currentNationality == "MKD") { currentOccludNatInt = 115; }
        if (currentNationality == "MLI") { currentOccludNatInt = 116; }
        if (currentNationality == "MMR") { currentOccludNatInt = 117; }
        if (currentNationality == "MNG") { currentOccludNatInt = 118; }
        if (currentNationality == "MAC") { currentOccludNatInt = 119; }
        if (currentNationality == "MRT") { currentOccludNatInt = 120; }
        if (currentNationality == "MLT") { currentOccludNatInt = 121; }
        if (currentNationality == "MUS") { currentOccludNatInt = 122; }
        if (currentNationality == "MDV") { currentOccludNatInt = 123; }
        if (currentNationality == "MWI") { currentOccludNatInt = 124; }
        if (currentNationality == "MEX") { currentOccludNatInt = 125; }
        if (currentNationality == "MYS") { currentOccludNatInt = 126; }
        if (currentNationality == "MOZ") { currentOccludNatInt = 127; }
        if (currentNationality == "NAM") { currentOccludNatInt = 128; }
        if (currentNationality == "NER") { currentOccludNatInt = 129; }
        if (currentNationality == "NGA") { currentOccludNatInt = 130; }
        if (currentNationality == "NIC") { currentOccludNatInt = 131; }
        if (currentNationality == "NLD") { currentOccludNatInt = 132; }
        if (currentNationality == "NOR") { currentOccludNatInt = 133; }
        if (currentNationality == "NPL") { currentOccludNatInt = 134; }
        if (currentNationality == "NRU") { currentOccludNatInt = 135; }
        if (currentNationality == "NZL") { currentOccludNatInt = 136; }
        if (currentNationality == "OMN") { currentOccludNatInt = 137; }
        if (currentNationality == "PAN") { currentOccludNatInt = 138; }
        if (currentNationality == "PER") { currentOccludNatInt = 139; }
        if (currentNationality == "PNG") { currentOccludNatInt = 140; }
        if (currentNationality == "PHL") { currentOccludNatInt = 141; }
        if (currentNationality == "PAK") { currentOccludNatInt = 142; }
        if (currentNationality == "POL") { currentOccludNatInt = 143; }
        if (currentNationality == "PSE") { currentOccludNatInt = 144; }
        if (currentNationality == "PRT") { currentOccludNatInt = 145; }
        if (currentNationality == "PLW") { currentOccludNatInt = 146; }
        if (currentNationality == "PRY") { currentOccludNatInt = 147; }
        if (currentNationality == "QAT") { currentOccludNatInt = 148; }
        if (currentNationality == "KOS") { currentOccludNatInt = 149; }
        if (currentNationality == "ROU") { currentOccludNatInt = 150; }
        if (currentNationality == "SRB") { currentOccludNatInt = 151; }
        if (currentNationality == "RUS") { currentOccludNatInt = 152; }
        if (currentNationality == "RWA") { currentOccludNatInt = 153; }
        if (currentNationality == "SAU") { currentOccludNatInt = 154; }
        if (currentNationality == "SLB") { currentOccludNatInt = 155; }
        if (currentNationality == "SYC") { currentOccludNatInt = 156; }
        if (currentNationality == "SDN") { currentOccludNatInt = 157; }
        if (currentNationality == "SWE") { currentOccludNatInt = 158; }
        if (currentNationality == "SGP") { currentOccludNatInt = 159; }
        if (currentNationality == "SVN") { currentOccludNatInt = 160; }
        if (currentNationality == "SVK") { currentOccludNatInt = 161; }
        if (currentNationality == "SLE") { currentOccludNatInt = 162; }
        if (currentNationality == "SMR") { currentOccludNatInt = 163; }
        if (currentNationality == "SEN") { currentOccludNatInt = 164; }
        if (currentNationality == "SOM") { currentOccludNatInt = 165; }
        if (currentNationality == "SUR") { currentOccludNatInt = 166; }
        if (currentNationality == "SSD") { currentOccludNatInt = 167; }
        if (currentNationality == "STP") { currentOccludNatInt = 168; }
        if (currentNationality == "SLV") { currentOccludNatInt = 169; }
        if (currentNationality == "SYR") { currentOccludNatInt = 170; }
        if (currentNationality == "SWZ") { currentOccludNatInt = 171; }
        if (currentNationality == "TCD") { currentOccludNatInt = 172; }
        if (currentNationality == "TGO") { currentOccludNatInt = 173; }
        if (currentNationality == "THA") { currentOccludNatInt = 174; }
        if (currentNationality == "TJK") { currentOccludNatInt = 175; }
        if (currentNationality == "TLS") { currentOccludNatInt = 176; }
        if (currentNationality == "TKM") { currentOccludNatInt = 177; }
        if (currentNationality == "TUN") { currentOccludNatInt = 178; }
        if (currentNationality == "TON") { currentOccludNatInt = 179; }
        if (currentNationality == "TUR") { currentOccludNatInt = 180; }
        if (currentNationality == "TTO") { currentOccludNatInt = 181; }
        if (currentNationality == "TUV") { currentOccludNatInt = 182; }
        if (currentNationality == "TWN") { currentOccludNatInt = 183; }
        if (currentNationality == "TZA") { currentOccludNatInt = 184; }
        if (currentNationality == "UKR") { currentOccludNatInt = 185; }
        if (currentNationality == "UGA") { currentOccludNatInt = 186; }
        if (currentNationality == "USA") { currentOccludNatInt = 187; }
        if (currentNationality == "URY") { currentOccludNatInt = 188; }
        if (currentNationality == "UZB") { currentOccludNatInt = 189; }
        if (currentNationality == "VAT") { currentOccludNatInt = 190; }
        if (currentNationality == "VCT") { currentOccludNatInt = 191; }
        if (currentNationality == "VEN") { currentOccludNatInt = 192; }
        if (currentNationality == "VNM") { currentOccludNatInt = 193; }
        if (currentNationality == "VUT") { currentOccludNatInt = 194; }
        if (currentNationality == "WSM") { currentOccludNatInt = 195; }
        if (currentNationality == "YEM") { currentOccludNatInt = 196; }
        if (currentNationality == "ZAF") { currentOccludNatInt = 197; }
        if (currentNationality == "ZMB") { currentOccludNatInt = 198; }
        if (currentNationality == "ZWE") { currentOccludNatInt = 199; }
        if (currentNationality == "GBR") { currentOccludNatInt = 200; }

        receivedPassportDataList = LoadPassportDataContr.sendData(currentOccludNatInt);

        for (int i = 0; i < receivedPassportDataList.Count; i++)
        {
            if (receivedCountryIDList[i] == "DONE")
            {
                execute();
            }
        }
    }

    public List<int> sendDataList()
    {
        return receivedPassportDataList;
    }

    public int gotClickedNumber()
    {
        return currentOccludNatInt;
    }

    private void execute()
    {
        //SET THE COLOURS
        for (int i = 0; i < receivedPassportDataList.Count; i++) //double check which list to take here
        {
            if (receivedPassportDataList[i] == 1)
            {
                if (!visaReqCountries.Contains(receivedCountryIDList[i]))
                {
                    visaReqCountries.Add(receivedCountryIDList[i]);
                }
            }
            else if (receivedPassportDataList[i] == 2)
            {
                if (!visaECountries.Contains(receivedCountryIDList[i]))
                {
                    visaECountries.Add(receivedCountryIDList[i]);
                }
            }
            else if (receivedPassportDataList[i] == 3)
            {
                if (!visaOnArrCountries.Contains(receivedCountryIDList[i]))
                {
                    visaOnArrCountries.Add(receivedCountryIDList[i]);
                }
            }
            else if (receivedPassportDataList[i] == 4)
            {
                if (!visaFreeCountries.Contains(receivedCountryIDList[i]))
                {
                    visaFreeCountries.Add(receivedCountryIDList[i]);
                }
            }
            else if (receivedPassportDataList[i] == 5) //Country of Nationality
            {
                visaItselfIdentified = receivedCountryIDList[i];
            }
            else
            {
                setDefaultColor();
            }

        }
        setColorsVisaReq1();
        setColorsEVisa2();
        setColorsVoA3();
        setColorsVisaFree4();
        setColorsCountryItself();

        setColorsOnRenderers();
    }

    public void setPreQcountry()
    {
        if (playerNationalityfromForm == "Afghanistan") { currentNationalityInt = 3; }
        if (playerNationalityfromForm == "Albania") { currentNationalityInt = 5; }
        if (playerNationalityfromForm == "Algeria") { currentNationalityInt = 49; }
        if (playerNationalityfromForm == "Andorra") { currentNationalityInt = 1; }
        if (playerNationalityfromForm == "Angola") { currentNationalityInt = 7; }
        if (playerNationalityfromForm == "Antigua and Barbuda") { currentNationalityInt = 4; }
        if (playerNationalityfromForm == "Argentina") { currentNationalityInt = 8; }
        if (playerNationalityfromForm == "Armenia") { currentNationalityInt = 6; }
        if (playerNationalityfromForm == "Australia") { currentNationalityInt = 10; }
        if (playerNationalityfromForm == "Austria") { currentNationalityInt = 9; }
        if (playerNationalityfromForm == "Azerbaijan") { currentNationalityInt = 11; }
        if (playerNationalityfromForm == "Bahamas") { currentNationalityInt = 24; }
        if (playerNationalityfromForm == "Bahrain") { currentNationalityInt = 18; }
        if (playerNationalityfromForm == "Bangladesh") { currentNationalityInt = 14; }
        if (playerNationalityfromForm == "Barbados") { currentNationalityInt = 13; }
        if (playerNationalityfromForm == "Belarus") { currentNationalityInt = 27; }
        if (playerNationalityfromForm == "Belgium") { currentNationalityInt = 15; }
        if (playerNationalityfromForm == "Belize") { currentNationalityInt = 28; }
        if (playerNationalityfromForm == "Benin") { currentNationalityInt = 20; }
        if (playerNationalityfromForm == "Bhutan") { currentNationalityInt = 25; }
        if (playerNationalityfromForm == "Bolivia") { currentNationalityInt = 22; }
        if (playerNationalityfromForm == "Bosnia and Herzegovina") { currentNationalityInt = 12; }
        if (playerNationalityfromForm == "Botswana") { currentNationalityInt = 26; }
        if (playerNationalityfromForm == "Brazil") { currentNationalityInt = 23; }
        if (playerNationalityfromForm == "Brunei") { currentNationalityInt = 21; }
        if (playerNationalityfromForm == "Bulgaria") { currentNationalityInt = 17; }
        if (playerNationalityfromForm == "Burkina Faso") { currentNationalityInt = 16; }
        if (playerNationalityfromForm == "Burundi") { currentNationalityInt = 19; }
        if (playerNationalityfromForm == "Cambodia") { currentNationalityInt = 90; }
        if (playerNationalityfromForm == "Cameroon") { currentNationalityInt = 36; }
        if (playerNationalityfromForm == "Canada") { currentNationalityInt = 29; }
        if (playerNationalityfromForm == "CapeVerde") { currentNationalityInt = 41; }
        if (playerNationalityfromForm == "Central African Republic") { currentNationalityInt = 31; }
        if (playerNationalityfromForm == "Chad") { currentNationalityInt = 172; }
        if (playerNationalityfromForm == "Chile") { currentNationalityInt = 35; }
        if (playerNationalityfromForm == "China") { currentNationalityInt = 37; }
        if (playerNationalityfromForm == "Colombia") { currentNationalityInt = 38; }
        if (playerNationalityfromForm == "Comoros") { currentNationalityInt = 92; }
        if (playerNationalityfromForm == "Congo") { currentNationalityInt = 32; }
        if (playerNationalityfromForm == "Congo DR") { currentNationalityInt = 30; }
        if (playerNationalityfromForm == "Costa Rica") { currentNationalityInt = 39; }
        if (playerNationalityfromForm == "Cote d'Ivoire") { currentNationalityInt = 34; }
        if (playerNationalityfromForm == "Croatia") { currentNationalityInt = 74; }
        if (playerNationalityfromForm == "Cuba") { currentNationalityInt = 40; }
        if (playerNationalityfromForm == "Cyprus") { currentNationalityInt = 42; }
        if (playerNationalityfromForm == "Czech Republic") { currentNationalityInt = 43; }
        if (playerNationalityfromForm == "Denmark") { currentNationalityInt = 46; }
        if (playerNationalityfromForm == "Djibouti") { currentNationalityInt = 45; }
        if (playerNationalityfromForm == "Dominica") { currentNationalityInt = 47; }
        if (playerNationalityfromForm == "Dominican Republic") { currentNationalityInt = 48; }
        if (playerNationalityfromForm == "Ecuador") { currentNationalityInt = 50; }
        if (playerNationalityfromForm == "Egypt") { currentNationalityInt = 52; }
        if (playerNationalityfromForm == "El Salvador") { currentNationalityInt = 169; }
        if (playerNationalityfromForm == "Equatorial Guinea") { currentNationalityInt = 67; }
        if (playerNationalityfromForm == "Eritrea") { currentNationalityInt = 53; }
        if (playerNationalityfromForm == "Estonia") { currentNationalityInt = 51; }
        if (playerNationalityfromForm == "Ethiopia") { currentNationalityInt = 55; }
        if (playerNationalityfromForm == "Fiji") { currentNationalityInt = 57; }
        if (playerNationalityfromForm == "Finland") { currentNationalityInt = 56; }
        if (playerNationalityfromForm == "France") { currentNationalityInt = 59; }
        if (playerNationalityfromForm == "Gabon") { currentNationalityInt = 60; }
        if (playerNationalityfromForm == "Gambia") { currentNationalityInt = 65; }
        if (playerNationalityfromForm == "Georgia") { currentNationalityInt = 63; }
        if (playerNationalityfromForm == "Germany") { currentNationalityInt = 44; }
        if (playerNationalityfromForm == "Ghana") { currentNationalityInt = 64; }
        if (playerNationalityfromForm == "Greece") { currentNationalityInt = 68; }
        if (playerNationalityfromForm == "Grenada") { currentNationalityInt = 62; }
        if (playerNationalityfromForm == "Guatemala") { currentNationalityInt = 69; }
        if (playerNationalityfromForm == "Guinea") { currentNationalityInt = 66; }
        if (playerNationalityfromForm == "Guinea-Bissau") { currentNationalityInt = 70; }
        if (playerNationalityfromForm == "Guyana") { currentNationalityInt = 71; }
        if (playerNationalityfromForm == "Haiti") { currentNationalityInt = 75; }
        if (playerNationalityfromForm == "Vatican") { currentNationalityInt = 190; }
        if (playerNationalityfromForm == "Honduras") { currentNationalityInt = 73; }
        if (playerNationalityfromForm == "Hong Kong") { currentNationalityInt = 72; }
        if (playerNationalityfromForm == "Hungary") { currentNationalityInt = 76; }
        if (playerNationalityfromForm == "Iceland") { currentNationalityInt = 83; }
        if (playerNationalityfromForm == "India") { currentNationalityInt = 80; }
        if (playerNationalityfromForm == "Indonesia") { currentNationalityInt = 77; }
        if (playerNationalityfromForm == "Iran") { currentNationalityInt = 82; }
        if (playerNationalityfromForm == "Iraq") { currentNationalityInt = 81; }
        if (playerNationalityfromForm == "Ireland") { currentNationalityInt = 78; }
        if (playerNationalityfromForm == "Israel") { currentNationalityInt = 79; }
        if (playerNationalityfromForm == "Italy") { currentNationalityInt = 84; }
        if (playerNationalityfromForm == "Jamaica") { currentNationalityInt = 85; }
        if (playerNationalityfromForm == "Japan") { currentNationalityInt = 87; }
        if (playerNationalityfromForm == "Jordan") { currentNationalityInt = 86; }
        if (playerNationalityfromForm == "Kazakhstan") { currentNationalityInt = 97; }
        if (playerNationalityfromForm == "Kenya") { currentNationalityInt = 88; }
        if (playerNationalityfromForm == "Kiribati") { currentNationalityInt = 91; }
        if (playerNationalityfromForm == "North Korea") { currentNationalityInt = 94; }
        if (playerNationalityfromForm == "South Korea") { currentNationalityInt = 95; }
        if (playerNationalityfromForm == "Kosovo") { currentNationalityInt = 149; }
        if (playerNationalityfromForm == "Kuwait") { currentNationalityInt = 96; }
        if (playerNationalityfromForm == "Kyrgyzstan") { currentNationalityInt = 89; }
        if (playerNationalityfromForm == "Laos") { currentNationalityInt = 98; }
        if (playerNationalityfromForm == "Latvia") { currentNationalityInt = 107; }
        if (playerNationalityfromForm == "Lebanon") { currentNationalityInt = 99; }
        if (playerNationalityfromForm == "Lesotho") { currentNationalityInt = 104; }
        if (playerNationalityfromForm == "Liberia") { currentNationalityInt = 103; }
        if (playerNationalityfromForm == "Libya") { currentNationalityInt = 108; }
        if (playerNationalityfromForm == "Liechtenstein") { currentNationalityInt = 101; }
        if (playerNationalityfromForm == "Lithuania") { currentNationalityInt = 105; }
        if (playerNationalityfromForm == "Luxembourg") { currentNationalityInt = 106; }
        if (playerNationalityfromForm == "Macao") { currentNationalityInt = 119; }
        if (playerNationalityfromForm == "Madagascar") { currentNationalityInt = 113; }
        if (playerNationalityfromForm == "Malawi") { currentNationalityInt = 124; }
        if (playerNationalityfromForm == "Malaysia") { currentNationalityInt = 126; }
        if (playerNationalityfromForm == "Maldives") { currentNationalityInt = 123; }
        if (playerNationalityfromForm == "Mali") { currentNationalityInt = 116; }
        if (playerNationalityfromForm == "Malta") { currentNationalityInt = 121; }
        if (playerNationalityfromForm == "Marshall Islands") { currentNationalityInt = 114; }
        if (playerNationalityfromForm == "Mauritania") { currentNationalityInt = 120; }
        if (playerNationalityfromForm == "Mauritius") { currentNationalityInt = 122; }
        if (playerNationalityfromForm == "Mexico") { currentNationalityInt = 125; }
        if (playerNationalityfromForm == "Micronesia") { currentNationalityInt = 58; }
        if (playerNationalityfromForm == "Moldova") { currentNationalityInt = 111; }
        if (playerNationalityfromForm == "Monaco") { currentNationalityInt = 110; }
        if (playerNationalityfromForm == "Mongolia") { currentNationalityInt = 118; }
        if (playerNationalityfromForm == "Montenegro") { currentNationalityInt = 112; }
        if (playerNationalityfromForm == "Morocco") { currentNationalityInt = 109; }
        if (playerNationalityfromForm == "Mozambique") { currentNationalityInt = 127; }
        if (playerNationalityfromForm == "Myanmar") { currentNationalityInt = 117; }
        if (playerNationalityfromForm == "Namibia") { currentNationalityInt = 128; }
        if (playerNationalityfromForm == "Nauru") { currentNationalityInt = 135; }
        if (playerNationalityfromForm == "Nepal") { currentNationalityInt = 134; }
        if (playerNationalityfromForm == "Netherlands") { currentNationalityInt = 132; }
        if (playerNationalityfromForm == "New Zealand") { currentNationalityInt = 136; }
        if (playerNationalityfromForm == "Nicaragua") { currentNationalityInt = 131; }
        if (playerNationalityfromForm == "Niger") { currentNationalityInt = 129; }
        if (playerNationalityfromForm == "Nigeria") { currentNationalityInt = 130; }
        if (playerNationalityfromForm == "North Macedonia") { currentNationalityInt = 115; }
        if (playerNationalityfromForm == "Norway") { currentNationalityInt = 133; }
        if (playerNationalityfromForm == "Oman") { currentNationalityInt = 137; }
        if (playerNationalityfromForm == "Pakistan") { currentNationalityInt = 142; }
        if (playerNationalityfromForm == "Palau") { currentNationalityInt = 146; }
        if (playerNationalityfromForm == "Palestinian Territory") { currentNationalityInt = 144; }
        if (playerNationalityfromForm == "Panama") { currentNationalityInt = 138; }
        if (playerNationalityfromForm == "Papua New Guinea") { currentNationalityInt = 140; }
        if (playerNationalityfromForm == "Paraguay") { currentNationalityInt = 147; }
        if (playerNationalityfromForm == "Peru") { currentNationalityInt = 139; }
        if (playerNationalityfromForm == "Philippines") { currentNationalityInt = 141; }
        if (playerNationalityfromForm == "Poland") { currentNationalityInt = 143; }
        if (playerNationalityfromForm == "Portugal") { currentNationalityInt = 145; }
        if (playerNationalityfromForm == "Qatar") { currentNationalityInt = 148; }
        if (playerNationalityfromForm == "Romania") { currentNationalityInt = 150; }
        if (playerNationalityfromForm == "Russia") { currentNationalityInt = 152; }
        if (playerNationalityfromForm == "Rwanda") { currentNationalityInt = 153; }
        if (playerNationalityfromForm == "Saint Kitts and Nevis") { currentNationalityInt = 93; }
        if (playerNationalityfromForm == "Saint Lucia") { currentNationalityInt = 100; }
        if (playerNationalityfromForm == "Saint Vincent and the Grenadines") { currentNationalityInt = 191; }
        if (playerNationalityfromForm == "Samoa") { currentNationalityInt = 195; }
        if (playerNationalityfromForm == "SanMarino") { currentNationalityInt = 163; }
        if (playerNationalityfromForm == "Sao Tome and Principe") { currentNationalityInt = 168; }
        if (playerNationalityfromForm == "Saudi Arabia") { currentNationalityInt = 154; }
        if (playerNationalityfromForm == "Senegal") { currentNationalityInt = 164; }
        if (playerNationalityfromForm == "Serbia") { currentNationalityInt = 151; }
        if (playerNationalityfromForm == "Seychelles") { currentNationalityInt = 156; }
        if (playerNationalityfromForm == "Sierra Leone") { currentNationalityInt = 162; }
        if (playerNationalityfromForm == "Singapore") { currentNationalityInt = 159; }
        if (playerNationalityfromForm == "Slovakia") { currentNationalityInt = 161; }
        if (playerNationalityfromForm == "Slovenia") { currentNationalityInt = 160; }
        if (playerNationalityfromForm == "Solomon Islands") { currentNationalityInt = 155; }
        if (playerNationalityfromForm == "Somalia") { currentNationalityInt = 165; }
        if (playerNationalityfromForm == "South Africa") { currentNationalityInt = 197; }
        if (playerNationalityfromForm == "South Sudan") { currentNationalityInt = 167; }
        if (playerNationalityfromForm == "Spain") { currentNationalityInt = 54; }
        if (playerNationalityfromForm == "Sri Lanka") { currentNationalityInt = 102; }
        if (playerNationalityfromForm == "Sudan") { currentNationalityInt = 157; }
        if (playerNationalityfromForm == "Suriname") { currentNationalityInt = 166; }
        if (playerNationalityfromForm == "Swaziland") { currentNationalityInt = 171; }
        if (playerNationalityfromForm == "Sweden") { currentNationalityInt = 158; }
        if (playerNationalityfromForm == "Switzerland") { currentNationalityInt = 33; }
        if (playerNationalityfromForm == "Syria") { currentNationalityInt = 170; }
        if (playerNationalityfromForm == "Taiwan") { currentNationalityInt = 183; }
        if (playerNationalityfromForm == "Tajikistan") { currentNationalityInt = 175; }
        if (playerNationalityfromForm == "Tanzania") { currentNationalityInt = 184; }
        if (playerNationalityfromForm == "Thailand") { currentNationalityInt = 174; }
        if (playerNationalityfromForm == "Timor-Leste") { currentNationalityInt = 176; }
        if (playerNationalityfromForm == "Togo") { currentNationalityInt = 173; }
        if (playerNationalityfromForm == "Tonga") { currentNationalityInt = 179; }
        if (playerNationalityfromForm == "Trinidad and Tobago") { currentNationalityInt = 181; }
        if (playerNationalityfromForm == "Tunisia") { currentNationalityInt = 178; }
        if (playerNationalityfromForm == "Turkey") { currentNationalityInt = 180; }
        if (playerNationalityfromForm == "Turkmenistan") { currentNationalityInt = 177; }
        if (playerNationalityfromForm == "Tuvalu") { currentNationalityInt = 182; }
        if (playerNationalityfromForm == "Uganda") { currentNationalityInt = 186; }
        if (playerNationalityfromForm == "Ukraine") { currentNationalityInt = 185; }
        if (playerNationalityfromForm == "United Arab Emirates") { currentNationalityInt = 2; }
        if (playerNationalityfromForm == "United Kingdom") { currentNationalityInt = 61; }
        if (playerNationalityfromForm == "United States of America") { currentNationalityInt = 187; }
        if (playerNationalityfromForm == "Uruguay") { currentNationalityInt = 188; }
        if (playerNationalityfromForm == "Uzbekistan") { currentNationalityInt = 189; }
        if (playerNationalityfromForm == "Vanuatu") { currentNationalityInt = 194; }
        if (playerNationalityfromForm == "Venezuela") { currentNationalityInt = 192; }
        if (playerNationalityfromForm == "Vietnam") { currentNationalityInt = 193; }
        if (playerNationalityfromForm == "Yemen") { currentNationalityInt = 196; }
        if (playerNationalityfromForm == "Zambia") { currentNationalityInt = 198; }
        if (playerNationalityfromForm == "Zimbabwe") { currentNationalityInt = 199; }
    }

    public void setColorsVisaReq1()
    {
        for (int i = 0; i < visaReqCountries.Count; i++)
        {
            if (visaReqCountries[i] == "AFG") { AFG_color = visaReq1color; }
            if (visaReqCountries[i] == "ALB") { ALB_color = visaReq1color; }
            if (visaReqCountries[i] == "DZA") { DZA_color = visaReq1color; }
            if (visaReqCountries[i] == "AND") { AND_color = visaReq1color; }
            if (visaReqCountries[i] == "AGO") { AGO_color = visaReq1color; }
            if (visaReqCountries[i] == "ATG") { ATG_color = visaReq1color; }
            if (visaReqCountries[i] == "ARG") { ARG_color = visaReq1color; }
            if (visaReqCountries[i] == "ARM") { ARM_color = visaReq1color; }
            if (visaReqCountries[i] == "AUS") { AUS_color = visaReq1color; }
            if (visaReqCountries[i] == "AUT") { AUT_color = visaReq1color; }
            if (visaReqCountries[i] == "AZE") { AZE_color = visaReq1color; }
            if (visaReqCountries[i] == "BHS") { BHS_color = visaReq1color; }
            if (visaReqCountries[i] == "BHR") { BHR_color = visaReq1color; }
            if (visaReqCountries[i] == "BGD") { BGD_color = visaReq1color; }
            if (visaReqCountries[i] == "BRB") { BRB_color = visaReq1color; }
            if (visaReqCountries[i] == "BLR") { BLR_color = visaReq1color; }
            if (visaReqCountries[i] == "BEL") { BEL_color = visaReq1color; }
            if (visaReqCountries[i] == "BLZ") { BLZ_color = visaReq1color; }
            if (visaReqCountries[i] == "BEN") { BEN_color = visaReq1color; }
            if (visaReqCountries[i] == "BTN") { BTN_color = visaReq1color; }
            if (visaReqCountries[i] == "BOL") { BOL_color = visaReq1color; }
            if (visaReqCountries[i] == "BIH") { BIH_color = visaReq1color; }
            if (visaReqCountries[i] == "BWA") { BWA_color = visaReq1color; }
            if (visaReqCountries[i] == "BRA") { BRA_color = visaReq1color; }
            if (visaReqCountries[i] == "BRN") { BRN_color = visaReq1color; }
            if (visaReqCountries[i] == "BGR") { BGR_color = visaReq1color; }
            if (visaReqCountries[i] == "BFA") { BFA_color = visaReq1color; }
            if (visaReqCountries[i] == "BDI") { BDI_color = visaReq1color; }
            if (visaReqCountries[i] == "KHM") { KHM_color = visaReq1color; }
            if (visaReqCountries[i] == "CMR") { CMR_color = visaReq1color; }
            if (visaReqCountries[i] == "CAN") { CAN_color = visaReq1color; }
            if (visaReqCountries[i] == "CPV") { CPV_color = visaReq1color; }
            if (visaReqCountries[i] == "CAF") { CAF_color = visaReq1color; }
            if (visaReqCountries[i] == "TCD") { TCD_color = visaReq1color; }
            if (visaReqCountries[i] == "CHL") { CHL_color = visaReq1color; }
            if (visaReqCountries[i] == "CHN") { CHN_color = visaReq1color; }
            if (visaReqCountries[i] == "COL") { COL_color = visaReq1color; }
            if (visaReqCountries[i] == "COM") { COM_color = visaReq1color; }
            if (visaReqCountries[i] == "COG") { COG_color = visaReq1color; }
            if (visaReqCountries[i] == "COD") { COD_color = visaReq1color; }
            if (visaReqCountries[i] == "CRI") { CRI_color = visaReq1color; }
            if (visaReqCountries[i] == "CIV") { CIV_color = visaReq1color; }
            if (visaReqCountries[i] == "HRV") { HRV_color = visaReq1color; }
            if (visaReqCountries[i] == "CUB") { CUB_color = visaReq1color; }
            if (visaReqCountries[i] == "CYP") { CYP_color = visaReq1color; }
            if (visaReqCountries[i] == "CZE") { CZE_color = visaReq1color; }
            if (visaReqCountries[i] == "DNK") { DNK_color = visaReq1color; }
            if (visaReqCountries[i] == "DJI") { DJI_color = visaReq1color; }
            if (visaReqCountries[i] == "DMA") { DMA_color = visaReq1color; }
            if (visaReqCountries[i] == "DOM") { DOM_color = visaReq1color; }
            if (visaReqCountries[i] == "ECU") { ECU_color = visaReq1color; }
            if (visaReqCountries[i] == "EGY") { EGY_color = visaReq1color; }
            if (visaReqCountries[i] == "SLV") { SLV_color = visaReq1color; }
            if (visaReqCountries[i] == "GNQ") { GNQ_color = visaReq1color; }
            if (visaReqCountries[i] == "ERI") { ERI_color = visaReq1color; }
            if (visaReqCountries[i] == "EST") { EST_color = visaReq1color; }
            if (visaReqCountries[i] == "ETH") { ETH_color = visaReq1color; }
            if (visaReqCountries[i] == "FJI") { FJI_color = visaReq1color; }
            if (visaReqCountries[i] == "FIN") { FIN_color = visaReq1color; }
            if (visaReqCountries[i] == "FRA") { FRA_color = visaReq1color; }
            if (visaReqCountries[i] == "GAB") { GAB_color = visaReq1color; }
            if (visaReqCountries[i] == "GMB") { GMB_color = visaReq1color; }
            if (visaReqCountries[i] == "GEO") { GEO_color = visaReq1color; }
            if (visaReqCountries[i] == "DEU") { DEU_color = visaReq1color; }
            if (visaReqCountries[i] == "GHA") { GHA_color = visaReq1color; }
            if (visaReqCountries[i] == "GRC") { GRC_color = visaReq1color; }
            if (visaReqCountries[i] == "GRD") { GRD_color = visaReq1color; }
            if (visaReqCountries[i] == "GTM") { GTM_color = visaReq1color; }
            if (visaReqCountries[i] == "GIN") { GIN_color = visaReq1color; }
            if (visaReqCountries[i] == "GNB") { GNB_color = visaReq1color; }
            if (visaReqCountries[i] == "GUY") { GUY_color = visaReq1color; }
            if (visaReqCountries[i] == "HTI") { HTI_color = visaReq1color; }
            if (visaReqCountries[i] == "VAT") { VAT_color = visaReq1color; }
            if (visaReqCountries[i] == "HND") { HND_color = visaReq1color; }
            if (visaReqCountries[i] == "HKG") { HKG_color = visaReq1color; }
            if (visaReqCountries[i] == "HUN") { HUN_color = visaReq1color; }
            if (visaReqCountries[i] == "ISL") { ISL_color = visaReq1color; }
            if (visaReqCountries[i] == "IND") { IND_color = visaReq1color; }
            if (visaReqCountries[i] == "IDN") { IDN_color = visaReq1color; }
            if (visaReqCountries[i] == "IRN") { IRN_color = visaReq1color; }
            if (visaReqCountries[i] == "IRQ") { IRQ_color = visaReq1color; }
            if (visaReqCountries[i] == "IRL") { IRL_color = visaReq1color; }
            if (visaReqCountries[i] == "ISR") { ISR_color = visaReq1color; }
            if (visaReqCountries[i] == "ITA") { ITA_color = visaReq1color; }
            if (visaReqCountries[i] == "JAM") { JAM_color = visaReq1color; }
            if (visaReqCountries[i] == "JPN") { JPN_color = visaReq1color; }
            if (visaReqCountries[i] == "JOR") { JOR_color = visaReq1color; }
            if (visaReqCountries[i] == "KAZ") { KAZ_color = visaReq1color; }
            if (visaReqCountries[i] == "KEN") { KEN_color = visaReq1color; }
            if (visaReqCountries[i] == "KIR") { KIR_color = visaReq1color; }
            if (visaReqCountries[i] == "PRK") { PRK_color = visaReq1color; }
            if (visaReqCountries[i] == "KOR") { KOR_color = visaReq1color; }
            if (visaReqCountries[i] == "KOS") { KOS_color = visaReq1color; }
            if (visaReqCountries[i] == "KWT") { KWT_color = visaReq1color; }
            if (visaReqCountries[i] == "KGZ") { KGZ_color = visaReq1color; }
            if (visaReqCountries[i] == "LAO") { LAO_color = visaReq1color; }
            if (visaReqCountries[i] == "LVA") { LVA_color = visaReq1color; }
            if (visaReqCountries[i] == "LBN") { LBN_color = visaReq1color; }
            if (visaReqCountries[i] == "LSO") { LSO_color = visaReq1color; }
            if (visaReqCountries[i] == "LBR") { LBR_color = visaReq1color; }
            if (visaReqCountries[i] == "LBY") { LBY_color = visaReq1color; }
            if (visaReqCountries[i] == "LIE") { LIE_color = visaReq1color; }
            if (visaReqCountries[i] == "LTU") { LTU_color = visaReq1color; }
            if (visaReqCountries[i] == "LUX") { LUX_color = visaReq1color; }
            if (visaReqCountries[i] == "MAC") { MAC_color = visaReq1color; }
            if (visaReqCountries[i] == "MDG") { MDG_color = visaReq1color; }
            if (visaReqCountries[i] == "MWI") { MWI_color = visaReq1color; }
            if (visaReqCountries[i] == "MYS") { MYS_color = visaReq1color; }
            if (visaReqCountries[i] == "MDV") { MDV_color = visaReq1color; }
            if (visaReqCountries[i] == "MLI") { MLI_color = visaReq1color; }
            if (visaReqCountries[i] == "MLT") { MLT_color = visaReq1color; }
            if (visaReqCountries[i] == "MHL") { MHL_color = visaReq1color; }
            if (visaReqCountries[i] == "MRT") { MRT_color = visaReq1color; }
            if (visaReqCountries[i] == "MUS") { MUS_color = visaReq1color; }
            if (visaReqCountries[i] == "MEX") { MEX_color = visaReq1color; }
            if (visaReqCountries[i] == "FSM") { FSM_color = visaReq1color; }
            if (visaReqCountries[i] == "MDA") { MDA_color = visaReq1color; }
            if (visaReqCountries[i] == "MCO") { MCO_color = visaReq1color; }
            if (visaReqCountries[i] == "MNG") { MNG_color = visaReq1color; }
            if (visaReqCountries[i] == "MNE") { MNE_color = visaReq1color; }
            if (visaReqCountries[i] == "MAR") { MAR_color = visaReq1color; }
            if (visaReqCountries[i] == "MOZ") { MOZ_color = visaReq1color; }
            if (visaReqCountries[i] == "MMR") { MMR_color = visaReq1color; }
            if (visaReqCountries[i] == "NAM") { NAM_color = visaReq1color; }
            if (visaReqCountries[i] == "NRU") { NRU_color = visaReq1color; }
            if (visaReqCountries[i] == "NPL") { NPL_color = visaReq1color; }
            if (visaReqCountries[i] == "NLD") { NLD_color = visaReq1color; }
            if (visaReqCountries[i] == "NZL") { NZL_color = visaReq1color; }
            if (visaReqCountries[i] == "NIC") { NIC_color = visaReq1color; }
            if (visaReqCountries[i] == "NER") { NER_color = visaReq1color; }
            if (visaReqCountries[i] == "NGA") { NGA_color = visaReq1color; }
            if (visaReqCountries[i] == "MKD") { MKD_color = visaReq1color; }
            if (visaReqCountries[i] == "NOR") { NOR_color = visaReq1color; }
            if (visaReqCountries[i] == "OMN") { OMN_color = visaReq1color; }
            if (visaReqCountries[i] == "PAK") { PAK_color = visaReq1color; }
            if (visaReqCountries[i] == "PLW") { PLW_color = visaReq1color; }
            if (visaReqCountries[i] == "PSE") { PSE_color = visaReq1color; }
            if (visaReqCountries[i] == "PAN") { PAN_color = visaReq1color; }
            if (visaReqCountries[i] == "PNG") { PNG_color = visaReq1color; }
            if (visaReqCountries[i] == "PRY") { PRY_color = visaReq1color; }
            if (visaReqCountries[i] == "PER") { PER_color = visaReq1color; }
            if (visaReqCountries[i] == "PHL") { PHL_color = visaReq1color; }
            if (visaReqCountries[i] == "POL") { POL_color = visaReq1color; }
            if (visaReqCountries[i] == "PRT") { PRT_color = visaReq1color; }
            if (visaReqCountries[i] == "QAT") { QAT_color = visaReq1color; }
            if (visaReqCountries[i] == "ROU") { ROU_color = visaReq1color; }
            if (visaReqCountries[i] == "RUS") { RUS_color = visaReq1color; }
            if (visaReqCountries[i] == "RWA") { RWA_color = visaReq1color; }
            if (visaReqCountries[i] == "KNA") { KNA_color = visaReq1color; }
            if (visaReqCountries[i] == "LCA") { LCA_color = visaReq1color; }
            if (visaReqCountries[i] == "VCT") { VCT_color = visaReq1color; }
            if (visaReqCountries[i] == "WSM") { WSM_color = visaReq1color; }
            if (visaReqCountries[i] == "SMR") { SMR_color = visaReq1color; }
            if (visaReqCountries[i] == "STP") { STP_color = visaReq1color; }
            if (visaReqCountries[i] == "SAU") { SAU_color = visaReq1color; }
            if (visaReqCountries[i] == "SEN") { SEN_color = visaReq1color; }
            if (visaReqCountries[i] == "SRB") { SRB_color = visaReq1color; }
            if (visaReqCountries[i] == "SYC") { SYC_color = visaReq1color; }
            if (visaReqCountries[i] == "SLE") { SLE_color = visaReq1color; }
            if (visaReqCountries[i] == "SGP") { SGP_color = visaReq1color; }
            if (visaReqCountries[i] == "SVK") { SVK_color = visaReq1color; }
            if (visaReqCountries[i] == "SVN") { SVN_color = visaReq1color; }
            if (visaReqCountries[i] == "SLB") { SLB_color = visaReq1color; }
            if (visaReqCountries[i] == "SOM") { SOM_color = visaReq1color; }
            if (visaReqCountries[i] == "ZAF") { ZAF_color = visaReq1color; }
            if (visaReqCountries[i] == "SSD") { SSD_color = visaReq1color; }
            if (visaReqCountries[i] == "ESP") { ESP_color = visaReq1color; }
            if (visaReqCountries[i] == "LKA") { LKA_color = visaReq1color; }
            if (visaReqCountries[i] == "SDN") { SDN_color = visaReq1color; }
            if (visaReqCountries[i] == "SUR") { SUR_color = visaReq1color; }
            if (visaReqCountries[i] == "SWZ") { SWZ_color = visaReq1color; }
            if (visaReqCountries[i] == "SWE") { SWE_color = visaReq1color; }
            if (visaReqCountries[i] == "CHE") { CHE_color = visaReq1color; }
            if (visaReqCountries[i] == "SYR") { SYR_color = visaReq1color; }
            if (visaReqCountries[i] == "TWN") { TWN_color = visaReq1color; }
            if (visaReqCountries[i] == "TJK") { TJK_color = visaReq1color; }
            if (visaReqCountries[i] == "TZA") { TZA_color = visaReq1color; }
            if (visaReqCountries[i] == "THA") { THA_color = visaReq1color; }
            if (visaReqCountries[i] == "TLS") { TLS_color = visaReq1color; }
            if (visaReqCountries[i] == "TGO") { TGO_color = visaReq1color; }
            if (visaReqCountries[i] == "TON") { TON_color = visaReq1color; }
            if (visaReqCountries[i] == "TTO") { TTO_color = visaReq1color; }
            if (visaReqCountries[i] == "TUN") { TUN_color = visaReq1color; }
            if (visaReqCountries[i] == "TUR") { TUR_color = visaReq1color; }
            if (visaReqCountries[i] == "TKM") { TKM_color = visaReq1color; }
            if (visaReqCountries[i] == "TUV") { TUV_color = visaReq1color; }
            if (visaReqCountries[i] == "UGA") { UGA_color = visaReq1color; }
            if (visaReqCountries[i] == "UKR") { UKR_color = visaReq1color; }
            if (visaReqCountries[i] == "ARE") { ARE_color = visaReq1color; }
            if (visaReqCountries[i] == "GBR") { GBR_color = visaReq1color; }
            if (visaReqCountries[i] == "USA") { USA_color = visaReq1color; }
            if (visaReqCountries[i] == "URY") { URY_color = visaReq1color; }
            if (visaReqCountries[i] == "UZB") { UZB_color = visaReq1color; }
            if (visaReqCountries[i] == "VUT") { VUT_color = visaReq1color; }
            if (visaReqCountries[i] == "VEN") { VEN_color = visaReq1color; }
            if (visaReqCountries[i] == "VNM") { VNM_color = visaReq1color; }
            if (visaReqCountries[i] == "YEM") { YEM_color = visaReq1color; }
            if (visaReqCountries[i] == "ZMB") { ZMB_color = visaReq1color; }
            if (visaReqCountries[i] == "ZWE") { ZWE_color = visaReq1color; }
        }
    }

    public void setColorsEVisa2()
    {
        for (int i = 0; i < visaECountries.Count; i++)
        {
            if (visaECountries[i] == "AFG") { AFG_color = visaE2color; }
            if (visaECountries[i] == "ALB") { ALB_color = visaE2color; }
            if (visaECountries[i] == "DZA") { DZA_color = visaE2color; }
            if (visaECountries[i] == "AND") { AND_color = visaE2color; }
            if (visaECountries[i] == "AGO") { AGO_color = visaE2color; }
            if (visaECountries[i] == "ATG") { ATG_color = visaE2color; }
            if (visaECountries[i] == "ARG") { ARG_color = visaE2color; }
            if (visaECountries[i] == "ARM") { ARM_color = visaE2color; }
            if (visaECountries[i] == "AUS") { AUS_color = visaE2color; }
            if (visaECountries[i] == "AUT") { AUT_color = visaE2color; }
            if (visaECountries[i] == "AZE") { AZE_color = visaE2color; }
            if (visaECountries[i] == "BHS") { BHS_color = visaE2color; }
            if (visaECountries[i] == "BHR") { BHR_color = visaE2color; }
            if (visaECountries[i] == "BGD") { BGD_color = visaE2color; }
            if (visaECountries[i] == "BRB") { BRB_color = visaE2color; }
            if (visaECountries[i] == "BLR") { BLR_color = visaE2color; }
            if (visaECountries[i] == "BEL") { BEL_color = visaE2color; }
            if (visaECountries[i] == "BLZ") { BLZ_color = visaE2color; }
            if (visaECountries[i] == "BEN") { BEN_color = visaE2color; }
            if (visaECountries[i] == "BTN") { BTN_color = visaE2color; }
            if (visaECountries[i] == "BOL") { BOL_color = visaE2color; }
            if (visaECountries[i] == "BIH") { BIH_color = visaE2color; }
            if (visaECountries[i] == "BWA") { BWA_color = visaE2color; }
            if (visaECountries[i] == "BRA") { BRA_color = visaE2color; }
            if (visaECountries[i] == "BRN") { BRN_color = visaE2color; }
            if (visaECountries[i] == "BGR") { BGR_color = visaE2color; }
            if (visaECountries[i] == "BFA") { BFA_color = visaE2color; }
            if (visaECountries[i] == "BDI") { BDI_color = visaE2color; }
            if (visaECountries[i] == "KHM") { KHM_color = visaE2color; }
            if (visaECountries[i] == "CMR") { CMR_color = visaE2color; }
            if (visaECountries[i] == "CAN") { CAN_color = visaE2color; }
            if (visaECountries[i] == "CPV") { CPV_color = visaE2color; }
            if (visaECountries[i] == "CAF") { CAF_color = visaE2color; }
            if (visaECountries[i] == "TCD") { TCD_color = visaE2color; }
            if (visaECountries[i] == "CHL") { CHL_color = visaE2color; }
            if (visaECountries[i] == "CHN") { CHN_color = visaE2color; }
            if (visaECountries[i] == "COL") { COL_color = visaE2color; }
            if (visaECountries[i] == "COM") { COM_color = visaE2color; }
            if (visaECountries[i] == "COG") { COG_color = visaE2color; }
            if (visaECountries[i] == "COD") { COD_color = visaE2color; }
            if (visaECountries[i] == "CRI") { CRI_color = visaE2color; }
            if (visaECountries[i] == "CIV") { CIV_color = visaE2color; }
            if (visaECountries[i] == "HRV") { HRV_color = visaE2color; }
            if (visaECountries[i] == "CUB") { CUB_color = visaE2color; }
            if (visaECountries[i] == "CYP") { CYP_color = visaE2color; }
            if (visaECountries[i] == "CZE") { CZE_color = visaE2color; }
            if (visaECountries[i] == "DNK") { DNK_color = visaE2color; }
            if (visaECountries[i] == "DJI") { DJI_color = visaE2color; }
            if (visaECountries[i] == "DMA") { DMA_color = visaE2color; }
            if (visaECountries[i] == "DOM") { DOM_color = visaE2color; }
            if (visaECountries[i] == "ECU") { ECU_color = visaE2color; }
            if (visaECountries[i] == "EGY") { EGY_color = visaE2color; }
            if (visaECountries[i] == "SLV") { SLV_color = visaE2color; }
            if (visaECountries[i] == "GNQ") { GNQ_color = visaE2color; }
            if (visaECountries[i] == "ERI") { ERI_color = visaE2color; }
            if (visaECountries[i] == "EST") { EST_color = visaE2color; }
            if (visaECountries[i] == "ETH") { ETH_color = visaE2color; }
            if (visaECountries[i] == "FJI") { FJI_color = visaE2color; }
            if (visaECountries[i] == "FIN") { FIN_color = visaE2color; }
            if (visaECountries[i] == "FRA") { FRA_color = visaE2color; }
            if (visaECountries[i] == "GAB") { GAB_color = visaE2color; }
            if (visaECountries[i] == "GMB") { GMB_color = visaE2color; }
            if (visaECountries[i] == "GEO") { GEO_color = visaE2color; }
            if (visaECountries[i] == "DEU") { DEU_color = visaE2color; }
            if (visaECountries[i] == "GHA") { GHA_color = visaE2color; }
            if (visaECountries[i] == "GRC") { GRC_color = visaE2color; }
            if (visaECountries[i] == "GRD") { GRD_color = visaE2color; }
            if (visaECountries[i] == "GTM") { GTM_color = visaE2color; }
            if (visaECountries[i] == "GIN") { GIN_color = visaE2color; }
            if (visaECountries[i] == "GNB") { GNB_color = visaE2color; }
            if (visaECountries[i] == "GUY") { GUY_color = visaE2color; }
            if (visaECountries[i] == "HTI") { HTI_color = visaE2color; }
            if (visaECountries[i] == "VAT") { VAT_color = visaE2color; }
            if (visaECountries[i] == "HND") { HND_color = visaE2color; }
            if (visaECountries[i] == "HKG") { HKG_color = visaE2color; }
            if (visaECountries[i] == "HUN") { HUN_color = visaE2color; }
            if (visaECountries[i] == "ISL") { ISL_color = visaE2color; }
            if (visaECountries[i] == "IND") { IND_color = visaE2color; }
            if (visaECountries[i] == "IDN") { IDN_color = visaE2color; }
            if (visaECountries[i] == "IRN") { IRN_color = visaE2color; }
            if (visaECountries[i] == "IRQ") { IRQ_color = visaE2color; }
            if (visaECountries[i] == "IRL") { IRL_color = visaE2color; }
            if (visaECountries[i] == "ISR") { ISR_color = visaE2color; }
            if (visaECountries[i] == "ITA") { ITA_color = visaE2color; }
            if (visaECountries[i] == "JAM") { JAM_color = visaE2color; }
            if (visaECountries[i] == "JPN") { JPN_color = visaE2color; }
            if (visaECountries[i] == "JOR") { JOR_color = visaE2color; }
            if (visaECountries[i] == "KAZ") { KAZ_color = visaE2color; }
            if (visaECountries[i] == "KEN") { KEN_color = visaE2color; }
            if (visaECountries[i] == "KIR") { KIR_color = visaE2color; }
            if (visaECountries[i] == "PRK") { PRK_color = visaE2color; }
            if (visaECountries[i] == "KOR") { KOR_color = visaE2color; }
            if (visaECountries[i] == "KOS") { KOS_color = visaE2color; }
            if (visaECountries[i] == "KWT") { KWT_color = visaE2color; }
            if (visaECountries[i] == "KGZ") { KGZ_color = visaE2color; }
            if (visaECountries[i] == "LAO") { LAO_color = visaE2color; }
            if (visaECountries[i] == "LVA") { LVA_color = visaE2color; }
            if (visaECountries[i] == "LBN") { LBN_color = visaE2color; }
            if (visaECountries[i] == "LSO") { LSO_color = visaE2color; }
            if (visaECountries[i] == "LBR") { LBR_color = visaE2color; }
            if (visaECountries[i] == "LBY") { LBY_color = visaE2color; }
            if (visaECountries[i] == "LIE") { LIE_color = visaE2color; }
            if (visaECountries[i] == "LTU") { LTU_color = visaE2color; }
            if (visaECountries[i] == "LUX") { LUX_color = visaE2color; }
            if (visaECountries[i] == "MAC") { MAC_color = visaE2color; }
            if (visaECountries[i] == "MDG") { MDG_color = visaE2color; }
            if (visaECountries[i] == "MWI") { MWI_color = visaE2color; }
            if (visaECountries[i] == "MYS") { MYS_color = visaE2color; }
            if (visaECountries[i] == "MDV") { MDV_color = visaE2color; }
            if (visaECountries[i] == "MLI") { MLI_color = visaE2color; }
            if (visaECountries[i] == "MLT") { MLT_color = visaE2color; }
            if (visaECountries[i] == "MHL") { MHL_color = visaE2color; }
            if (visaECountries[i] == "MRT") { MRT_color = visaE2color; }
            if (visaECountries[i] == "MUS") { MUS_color = visaE2color; }
            if (visaECountries[i] == "MEX") { MEX_color = visaE2color; }
            if (visaECountries[i] == "FSM") { FSM_color = visaE2color; }
            if (visaECountries[i] == "MDA") { MDA_color = visaE2color; }
            if (visaECountries[i] == "MCO") { MCO_color = visaE2color; }
            if (visaECountries[i] == "MNG") { MNG_color = visaE2color; }
            if (visaECountries[i] == "MNE") { MNE_color = visaE2color; }
            if (visaECountries[i] == "MAR") { MAR_color = visaE2color; }
            if (visaECountries[i] == "MOZ") { MOZ_color = visaE2color; }
            if (visaECountries[i] == "MMR") { MMR_color = visaE2color; }
            if (visaECountries[i] == "NAM") { NAM_color = visaE2color; }
            if (visaECountries[i] == "NRU") { NRU_color = visaE2color; }
            if (visaECountries[i] == "NPL") { NPL_color = visaE2color; }
            if (visaECountries[i] == "NLD") { NLD_color = visaE2color; }
            if (visaECountries[i] == "NZL") { NZL_color = visaE2color; }
            if (visaECountries[i] == "NIC") { NIC_color = visaE2color; }
            if (visaECountries[i] == "NER") { NER_color = visaE2color; }
            if (visaECountries[i] == "NGA") { NGA_color = visaE2color; }
            if (visaECountries[i] == "MKD") { MKD_color = visaE2color; }
            if (visaECountries[i] == "NOR") { NOR_color = visaE2color; }
            if (visaECountries[i] == "OMN") { OMN_color = visaE2color; }
            if (visaECountries[i] == "PAK") { PAK_color = visaE2color; }
            if (visaECountries[i] == "PLW") { PLW_color = visaE2color; }
            if (visaECountries[i] == "PSE") { PSE_color = visaE2color; }
            if (visaECountries[i] == "PAN") { PAN_color = visaE2color; }
            if (visaECountries[i] == "PNG") { PNG_color = visaE2color; }
            if (visaECountries[i] == "PRY") { PRY_color = visaE2color; }
            if (visaECountries[i] == "PER") { PER_color = visaE2color; }
            if (visaECountries[i] == "PHL") { PHL_color = visaE2color; }
            if (visaECountries[i] == "POL") { POL_color = visaE2color; }
            if (visaECountries[i] == "PRT") { PRT_color = visaE2color; }
            if (visaECountries[i] == "QAT") { QAT_color = visaE2color; }
            if (visaECountries[i] == "ROU") { ROU_color = visaE2color; }
            if (visaECountries[i] == "RUS") { RUS_color = visaE2color; }
            if (visaECountries[i] == "RWA") { RWA_color = visaE2color; }
            if (visaECountries[i] == "KNA") { KNA_color = visaE2color; }
            if (visaECountries[i] == "LCA") { LCA_color = visaE2color; }
            if (visaECountries[i] == "VCT") { VCT_color = visaE2color; }
            if (visaECountries[i] == "WSM") { WSM_color = visaE2color; }
            if (visaECountries[i] == "SMR") { SMR_color = visaE2color; }
            if (visaECountries[i] == "STP") { STP_color = visaE2color; }
            if (visaECountries[i] == "SAU") { SAU_color = visaE2color; }
            if (visaECountries[i] == "SEN") { SEN_color = visaE2color; }
            if (visaECountries[i] == "SRB") { SRB_color = visaE2color; }
            if (visaECountries[i] == "SYC") { SYC_color = visaE2color; }
            if (visaECountries[i] == "SLE") { SLE_color = visaE2color; }
            if (visaECountries[i] == "SGP") { SGP_color = visaE2color; }
            if (visaECountries[i] == "SVK") { SVK_color = visaE2color; }
            if (visaECountries[i] == "SVN") { SVN_color = visaE2color; }
            if (visaECountries[i] == "SLB") { SLB_color = visaE2color; }
            if (visaECountries[i] == "SOM") { SOM_color = visaE2color; }
            if (visaECountries[i] == "ZAF") { ZAF_color = visaE2color; }
            if (visaECountries[i] == "SSD") { SSD_color = visaE2color; }
            if (visaECountries[i] == "ESP") { ESP_color = visaE2color; }
            if (visaECountries[i] == "LKA") { LKA_color = visaE2color; }
            if (visaECountries[i] == "SDN") { SDN_color = visaE2color; }
            if (visaECountries[i] == "SUR") { SUR_color = visaE2color; }
            if (visaECountries[i] == "SWZ") { SWZ_color = visaE2color; }
            if (visaECountries[i] == "SWE") { SWE_color = visaE2color; }
            if (visaECountries[i] == "CHE") { CHE_color = visaE2color; }
            if (visaECountries[i] == "SYR") { SYR_color = visaE2color; }
            if (visaECountries[i] == "TWN") { TWN_color = visaE2color; }
            if (visaECountries[i] == "TJK") { TJK_color = visaE2color; }
            if (visaECountries[i] == "TZA") { TZA_color = visaE2color; }
            if (visaECountries[i] == "THA") { THA_color = visaE2color; }
            if (visaECountries[i] == "TLS") { TLS_color = visaE2color; }
            if (visaECountries[i] == "TGO") { TGO_color = visaE2color; }
            if (visaECountries[i] == "TON") { TON_color = visaE2color; }
            if (visaECountries[i] == "TTO") { TTO_color = visaE2color; }
            if (visaECountries[i] == "TUN") { TUN_color = visaE2color; }
            if (visaECountries[i] == "TUR") { TUR_color = visaE2color; }
            if (visaECountries[i] == "TKM") { TKM_color = visaE2color; }
            if (visaECountries[i] == "TUV") { TUV_color = visaE2color; }
            if (visaECountries[i] == "UGA") { UGA_color = visaE2color; }
            if (visaECountries[i] == "UKR") { UKR_color = visaE2color; }
            if (visaECountries[i] == "ARE") { ARE_color = visaE2color; }
            if (visaECountries[i] == "GBR") { GBR_color = visaE2color; }
            if (visaECountries[i] == "USA") { USA_color = visaE2color; }
            if (visaECountries[i] == "URY") { URY_color = visaE2color; }
            if (visaECountries[i] == "UZB") { UZB_color = visaE2color; }
            if (visaECountries[i] == "VUT") { VUT_color = visaE2color; }
            if (visaECountries[i] == "VEN") { VEN_color = visaE2color; }
            if (visaECountries[i] == "VNM") { VNM_color = visaE2color; }
            if (visaECountries[i] == "YEM") { YEM_color = visaE2color; }
            if (visaECountries[i] == "ZMB") { ZMB_color = visaE2color; }
            if (visaECountries[i] == "ZWE") { ZWE_color = visaE2color; }
        }
    }

    public void setColorsVoA3()
    {
        for (int i = 0; i < visaOnArrCountries.Count; i++)
        {
            if (visaOnArrCountries[i] == "AFG") { AFG_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ALB") { ALB_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "DZA") { DZA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "AND") { AND_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "AGO") { AGO_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ATG") { ATG_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ARG") { ARG_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ARM") { ARM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "AUS") { AUS_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "AUT") { AUT_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "AZE") { AZE_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BHS") { BHS_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BHR") { BHR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BGD") { BGD_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BRB") { BRB_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BLR") { BLR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BEL") { BEL_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BLZ") { BLZ_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BEN") { BEN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BTN") { BTN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BOL") { BOL_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BIH") { BIH_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BWA") { BWA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BRA") { BRA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BRN") { BRN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BGR") { BGR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BFA") { BFA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "BDI") { BDI_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "KHM") { KHM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CMR") { CMR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CAN") { CAN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CPV") { CPV_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CAF") { CAF_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TCD") { TCD_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CHL") { CHL_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CHN") { CHN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "COL") { COL_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "COM") { COM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "COG") { COG_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "COD") { COD_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CRI") { CRI_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CIV") { CIV_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "HRV") { HRV_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CUB") { CUB_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CYP") { CYP_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CZE") { CZE_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "DNK") { DNK_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "DJI") { DJI_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "DMA") { DMA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "DOM") { DOM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ECU") { ECU_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "EGY") { EGY_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SLV") { SLV_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GNQ") { GNQ_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ERI") { ERI_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "EST") { EST_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ETH") { ETH_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "FJI") { FJI_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "FIN") { FIN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "FRA") { FRA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GAB") { GAB_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GMB") { GMB_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GEO") { GEO_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "DEU") { DEU_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GHA") { GHA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GRC") { GRC_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GRD") { GRD_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GTM") { GTM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GIN") { GIN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GNB") { GNB_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GUY") { GUY_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "HTI") { HTI_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "VAT") { VAT_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "HND") { HND_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "HKG") { HKG_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "HUN") { HUN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ISL") { ISL_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "IND") { IND_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "IDN") { IDN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "IRN") { IRN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "IRQ") { IRQ_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "IRL") { IRL_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ISR") { ISR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ITA") { ITA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "JAM") { JAM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "JPN") { JPN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "JOR") { JOR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "KAZ") { KAZ_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "KEN") { KEN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "KIR") { KIR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "PRK") { PRK_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "KOR") { KOR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "KOS") { KOS_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "KWT") { KWT_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "KGZ") { KGZ_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "LAO") { LAO_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "LVA") { LVA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "LBN") { LBN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "LSO") { LSO_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "LBR") { LBR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "LBY") { LBY_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "LIE") { LIE_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "LTU") { LTU_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "LUX") { LUX_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MAC") { MAC_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MDG") { MDG_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MWI") { MWI_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MYS") { MYS_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MDV") { MDV_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MLI") { MLI_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MLT") { MLT_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MHL") { MHL_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MRT") { MRT_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MUS") { MUS_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MEX") { MEX_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "FSM") { FSM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MDA") { MDA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MCO") { MCO_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MNG") { MNG_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MNE") { MNE_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MAR") { MAR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MOZ") { MOZ_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MMR") { MMR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "NAM") { NAM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "NRU") { NRU_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "NPL") { NPL_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "NLD") { NLD_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "NZL") { NZL_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "NIC") { NIC_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "NER") { NER_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "NGA") { NGA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "MKD") { MKD_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "NOR") { NOR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "OMN") { OMN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "PAK") { PAK_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "PLW") { PLW_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "PSE") { PSE_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "PAN") { PAN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "PNG") { PNG_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "PRY") { PRY_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "PER") { PER_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "PHL") { PHL_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "POL") { POL_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "PRT") { PRT_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "QAT") { QAT_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ROU") { ROU_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "RUS") { RUS_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "RWA") { RWA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "KNA") { KNA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "LCA") { LCA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "VCT") { VCT_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "WSM") { WSM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SMR") { SMR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "STP") { STP_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SAU") { SAU_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SEN") { SEN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SRB") { SRB_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SYC") { SYC_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SLE") { SLE_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SGP") { SGP_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SVK") { SVK_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SVN") { SVN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SLB") { SLB_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SOM") { SOM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ZAF") { ZAF_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SSD") { SSD_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ESP") { ESP_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "LKA") { LKA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SDN") { SDN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SUR") { SUR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SWZ") { SWZ_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SWE") { SWE_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "CHE") { CHE_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "SYR") { SYR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TWN") { TWN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TJK") { TJK_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TZA") { TZA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "THA") { THA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TLS") { TLS_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TGO") { TGO_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TON") { TON_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TTO") { TTO_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TUN") { TUN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TUR") { TUR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TKM") { TKM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "TUV") { TUV_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "UGA") { UGA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "UKR") { UKR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ARE") { ARE_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "GBR") { GBR_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "USA") { USA_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "URY") { URY_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "UZB") { UZB_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "VUT") { VUT_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "VEN") { VEN_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "VNM") { VNM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "YEM") { YEM_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ZMB") { ZMB_color = visaOnArr3color; }
            if (visaOnArrCountries[i] == "ZWE") { ZWE_color = visaOnArr3color; }
        }
    }

    public void setColorsVisaFree4()
    {
        for (int i = 0; i < visaFreeCountries.Count; i++)
        {
            if (visaFreeCountries[i] == "AFG") { AFG_color = visaFree4color; }
            if (visaFreeCountries[i] == "ALB") { ALB_color = visaFree4color; }
            if (visaFreeCountries[i] == "DZA") { DZA_color = visaFree4color; }
            if (visaFreeCountries[i] == "AND") { AND_color = visaFree4color; }
            if (visaFreeCountries[i] == "AGO") { AGO_color = visaFree4color; }
            if (visaFreeCountries[i] == "ATG") { ATG_color = visaFree4color; }
            if (visaFreeCountries[i] == "ARG") { ARG_color = visaFree4color; }
            if (visaFreeCountries[i] == "ARM") { ARM_color = visaFree4color; }
            if (visaFreeCountries[i] == "AUS") { AUS_color = visaFree4color; }
            if (visaFreeCountries[i] == "AUT") { AUT_color = visaFree4color; }
            if (visaFreeCountries[i] == "AZE") { AZE_color = visaFree4color; }
            if (visaFreeCountries[i] == "BHS") { BHS_color = visaFree4color; }
            if (visaFreeCountries[i] == "BHR") { BHR_color = visaFree4color; }
            if (visaFreeCountries[i] == "BGD") { BGD_color = visaFree4color; }
            if (visaFreeCountries[i] == "BRB") { BRB_color = visaFree4color; }
            if (visaFreeCountries[i] == "BLR") { BLR_color = visaFree4color; }
            if (visaFreeCountries[i] == "BEL") { BEL_color = visaFree4color; }
            if (visaFreeCountries[i] == "BLZ") { BLZ_color = visaFree4color; }
            if (visaFreeCountries[i] == "BEN") { BEN_color = visaFree4color; }
            if (visaFreeCountries[i] == "BTN") { BTN_color = visaFree4color; }
            if (visaFreeCountries[i] == "BOL") { BOL_color = visaFree4color; }
            if (visaFreeCountries[i] == "BIH") { BIH_color = visaFree4color; }
            if (visaFreeCountries[i] == "BWA") { BWA_color = visaFree4color; }
            if (visaFreeCountries[i] == "BRA") { BRA_color = visaFree4color; }
            if (visaFreeCountries[i] == "BRN") { BRN_color = visaFree4color; }
            if (visaFreeCountries[i] == "BGR") { BGR_color = visaFree4color; }
            if (visaFreeCountries[i] == "BFA") { BFA_color = visaFree4color; }
            if (visaFreeCountries[i] == "BDI") { BDI_color = visaFree4color; }
            if (visaFreeCountries[i] == "KHM") { KHM_color = visaFree4color; }
            if (visaFreeCountries[i] == "CMR") { CMR_color = visaFree4color; }
            if (visaFreeCountries[i] == "CAN") { CAN_color = visaFree4color; }
            if (visaFreeCountries[i] == "CPV") { CPV_color = visaFree4color; }
            if (visaFreeCountries[i] == "CAF") { CAF_color = visaFree4color; }
            if (visaFreeCountries[i] == "TCD") { TCD_color = visaFree4color; }
            if (visaFreeCountries[i] == "CHL") { CHL_color = visaFree4color; }
            if (visaFreeCountries[i] == "CHN") { CHN_color = visaFree4color; }
            if (visaFreeCountries[i] == "COL") { COL_color = visaFree4color; }
            if (visaFreeCountries[i] == "COM") { COM_color = visaFree4color; }
            if (visaFreeCountries[i] == "COG") { COG_color = visaFree4color; }
            if (visaFreeCountries[i] == "COD") { COD_color = visaFree4color; }
            if (visaFreeCountries[i] == "CRI") { CRI_color = visaFree4color; }
            if (visaFreeCountries[i] == "CIV") { CIV_color = visaFree4color; }
            if (visaFreeCountries[i] == "HRV") { HRV_color = visaFree4color; }
            if (visaFreeCountries[i] == "CUB") { CUB_color = visaFree4color; }
            if (visaFreeCountries[i] == "CYP") { CYP_color = visaFree4color; }
            if (visaFreeCountries[i] == "CZE") { CZE_color = visaFree4color; }
            if (visaFreeCountries[i] == "DNK") { DNK_color = visaFree4color; }
            if (visaFreeCountries[i] == "DJI") { DJI_color = visaFree4color; }
            if (visaFreeCountries[i] == "DMA") { DMA_color = visaFree4color; }
            if (visaFreeCountries[i] == "DOM") { DOM_color = visaFree4color; }
            if (visaFreeCountries[i] == "ECU") { ECU_color = visaFree4color; }
            if (visaFreeCountries[i] == "EGY") { EGY_color = visaFree4color; }
            if (visaFreeCountries[i] == "SLV") { SLV_color = visaFree4color; }
            if (visaFreeCountries[i] == "GNQ") { GNQ_color = visaFree4color; }
            if (visaFreeCountries[i] == "ERI") { ERI_color = visaFree4color; }
            if (visaFreeCountries[i] == "EST") { EST_color = visaFree4color; }
            if (visaFreeCountries[i] == "ETH") { ETH_color = visaFree4color; }
            if (visaFreeCountries[i] == "FJI") { FJI_color = visaFree4color; }
            if (visaFreeCountries[i] == "FIN") { FIN_color = visaFree4color; }
            if (visaFreeCountries[i] == "FRA") { FRA_color = visaFree4color; }
            if (visaFreeCountries[i] == "GAB") { GAB_color = visaFree4color; }
            if (visaFreeCountries[i] == "GMB") { GMB_color = visaFree4color; }
            if (visaFreeCountries[i] == "GEO") { GEO_color = visaFree4color; }
            if (visaFreeCountries[i] == "DEU") { DEU_color = visaFree4color; }
            if (visaFreeCountries[i] == "GHA") { GHA_color = visaFree4color; }
            if (visaFreeCountries[i] == "GRC") { GRC_color = visaFree4color; }
            if (visaFreeCountries[i] == "GRD") { GRD_color = visaFree4color; }
            if (visaFreeCountries[i] == "GTM") { GTM_color = visaFree4color; }
            if (visaFreeCountries[i] == "GIN") { GIN_color = visaFree4color; }
            if (visaFreeCountries[i] == "GNB") { GNB_color = visaFree4color; }
            if (visaFreeCountries[i] == "GUY") { GUY_color = visaFree4color; }
            if (visaFreeCountries[i] == "HTI") { HTI_color = visaFree4color; }
            if (visaFreeCountries[i] == "VAT") { VAT_color = visaFree4color; }
            if (visaFreeCountries[i] == "HND") { HND_color = visaFree4color; }
            if (visaFreeCountries[i] == "HKG") { HKG_color = visaFree4color; }
            if (visaFreeCountries[i] == "HUN") { HUN_color = visaFree4color; }
            if (visaFreeCountries[i] == "ISL") { ISL_color = visaFree4color; }
            if (visaFreeCountries[i] == "IND") { IND_color = visaFree4color; }
            if (visaFreeCountries[i] == "IDN") { IDN_color = visaFree4color; }
            if (visaFreeCountries[i] == "IRN") { IRN_color = visaFree4color; }
            if (visaFreeCountries[i] == "IRQ") { IRQ_color = visaFree4color; }
            if (visaFreeCountries[i] == "IRL") { IRL_color = visaFree4color; }
            if (visaFreeCountries[i] == "ISR") { ISR_color = visaFree4color; }
            if (visaFreeCountries[i] == "ITA") { ITA_color = visaFree4color; }
            if (visaFreeCountries[i] == "JAM") { JAM_color = visaFree4color; }
            if (visaFreeCountries[i] == "JPN") { JPN_color = visaFree4color; }
            if (visaFreeCountries[i] == "JOR") { JOR_color = visaFree4color; }
            if (visaFreeCountries[i] == "KAZ") { KAZ_color = visaFree4color; }
            if (visaFreeCountries[i] == "KEN") { KEN_color = visaFree4color; }
            if (visaFreeCountries[i] == "KIR") { KIR_color = visaFree4color; }
            if (visaFreeCountries[i] == "PRK") { PRK_color = visaFree4color; }
            if (visaFreeCountries[i] == "KOR") { KOR_color = visaFree4color; }
            if (visaFreeCountries[i] == "KOS") { KOS_color = visaFree4color; }
            if (visaFreeCountries[i] == "KWT") { KWT_color = visaFree4color; }
            if (visaFreeCountries[i] == "KGZ") { KGZ_color = visaFree4color; }
            if (visaFreeCountries[i] == "LAO") { LAO_color = visaFree4color; }
            if (visaFreeCountries[i] == "LVA") { LVA_color = visaFree4color; }
            if (visaFreeCountries[i] == "LBN") { LBN_color = visaFree4color; }
            if (visaFreeCountries[i] == "LSO") { LSO_color = visaFree4color; }
            if (visaFreeCountries[i] == "LBR") { LBR_color = visaFree4color; }
            if (visaFreeCountries[i] == "LBY") { LBY_color = visaFree4color; }
            if (visaFreeCountries[i] == "LIE") { LIE_color = visaFree4color; }
            if (visaFreeCountries[i] == "LTU") { LTU_color = visaFree4color; }
            if (visaFreeCountries[i] == "LUX") { LUX_color = visaFree4color; }
            if (visaFreeCountries[i] == "MAC") { MAC_color = visaFree4color; }
            if (visaFreeCountries[i] == "MDG") { MDG_color = visaFree4color; }
            if (visaFreeCountries[i] == "MWI") { MWI_color = visaFree4color; }
            if (visaFreeCountries[i] == "MYS") { MYS_color = visaFree4color; }
            if (visaFreeCountries[i] == "MDV") { MDV_color = visaFree4color; }
            if (visaFreeCountries[i] == "MLI") { MLI_color = visaFree4color; }
            if (visaFreeCountries[i] == "MLT") { MLT_color = visaFree4color; }
            if (visaFreeCountries[i] == "MHL") { MHL_color = visaFree4color; }
            if (visaFreeCountries[i] == "MRT") { MRT_color = visaFree4color; }
            if (visaFreeCountries[i] == "MUS") { MUS_color = visaFree4color; }
            if (visaFreeCountries[i] == "MEX") { MEX_color = visaFree4color; }
            if (visaFreeCountries[i] == "FSM") { FSM_color = visaFree4color; }
            if (visaFreeCountries[i] == "MDA") { MDA_color = visaFree4color; }
            if (visaFreeCountries[i] == "MCO") { MCO_color = visaFree4color; }
            if (visaFreeCountries[i] == "MNG") { MNG_color = visaFree4color; }
            if (visaFreeCountries[i] == "MNE") { MNE_color = visaFree4color; }
            if (visaFreeCountries[i] == "MAR") { MAR_color = visaFree4color; }
            if (visaFreeCountries[i] == "MOZ") { MOZ_color = visaFree4color; }
            if (visaFreeCountries[i] == "MMR") { MMR_color = visaFree4color; }
            if (visaFreeCountries[i] == "NAM") { NAM_color = visaFree4color; }
            if (visaFreeCountries[i] == "NRU") { NRU_color = visaFree4color; }
            if (visaFreeCountries[i] == "NPL") { NPL_color = visaFree4color; }
            if (visaFreeCountries[i] == "NLD") { NLD_color = visaFree4color; }
            if (visaFreeCountries[i] == "NZL") { NZL_color = visaFree4color; }
            if (visaFreeCountries[i] == "NIC") { NIC_color = visaFree4color; }
            if (visaFreeCountries[i] == "NER") { NER_color = visaFree4color; }
            if (visaFreeCountries[i] == "NGA") { NGA_color = visaFree4color; }
            if (visaFreeCountries[i] == "MKD") { MKD_color = visaFree4color; }
            if (visaFreeCountries[i] == "NOR") { NOR_color = visaFree4color; }
            if (visaFreeCountries[i] == "OMN") { OMN_color = visaFree4color; }
            if (visaFreeCountries[i] == "PAK") { PAK_color = visaFree4color; }
            if (visaFreeCountries[i] == "PLW") { PLW_color = visaFree4color; }
            if (visaFreeCountries[i] == "PSE") { PSE_color = visaFree4color; }
            if (visaFreeCountries[i] == "PAN") { PAN_color = visaFree4color; }
            if (visaFreeCountries[i] == "PNG") { PNG_color = visaFree4color; }
            if (visaFreeCountries[i] == "PRY") { PRY_color = visaFree4color; }
            if (visaFreeCountries[i] == "PER") { PER_color = visaFree4color; }
            if (visaFreeCountries[i] == "PHL") { PHL_color = visaFree4color; }
            if (visaFreeCountries[i] == "POL") { POL_color = visaFree4color; }
            if (visaFreeCountries[i] == "PRT") { PRT_color = visaFree4color; }
            if (visaFreeCountries[i] == "QAT") { QAT_color = visaFree4color; }
            if (visaFreeCountries[i] == "ROU") { ROU_color = visaFree4color; }
            if (visaFreeCountries[i] == "RUS") { RUS_color = visaFree4color; }
            if (visaFreeCountries[i] == "RWA") { RWA_color = visaFree4color; }
            if (visaFreeCountries[i] == "KNA") { KNA_color = visaFree4color; }
            if (visaFreeCountries[i] == "LCA") { LCA_color = visaFree4color; }
            if (visaFreeCountries[i] == "VCT") { VCT_color = visaFree4color; }
            if (visaFreeCountries[i] == "WSM") { WSM_color = visaFree4color; }
            if (visaFreeCountries[i] == "SMR") { SMR_color = visaFree4color; }
            if (visaFreeCountries[i] == "STP") { STP_color = visaFree4color; }
            if (visaFreeCountries[i] == "SAU") { SAU_color = visaFree4color; }
            if (visaFreeCountries[i] == "SEN") { SEN_color = visaFree4color; }
            if (visaFreeCountries[i] == "SRB") { SRB_color = visaFree4color; }
            if (visaFreeCountries[i] == "SYC") { SYC_color = visaFree4color; }
            if (visaFreeCountries[i] == "SLE") { SLE_color = visaFree4color; }
            if (visaFreeCountries[i] == "SGP") { SGP_color = visaFree4color; }
            if (visaFreeCountries[i] == "SVK") { SVK_color = visaFree4color; }
            if (visaFreeCountries[i] == "SVN") { SVN_color = visaFree4color; }
            if (visaFreeCountries[i] == "SLB") { SLB_color = visaFree4color; }
            if (visaFreeCountries[i] == "SOM") { SOM_color = visaFree4color; }
            if (visaFreeCountries[i] == "ZAF") { ZAF_color = visaFree4color; }
            if (visaFreeCountries[i] == "SSD") { SSD_color = visaFree4color; }
            if (visaFreeCountries[i] == "ESP") { ESP_color = visaFree4color; }
            if (visaFreeCountries[i] == "LKA") { LKA_color = visaFree4color; }
            if (visaFreeCountries[i] == "SDN") { SDN_color = visaFree4color; }
            if (visaFreeCountries[i] == "SUR") { SUR_color = visaFree4color; }
            if (visaFreeCountries[i] == "SWZ") { SWZ_color = visaFree4color; }
            if (visaFreeCountries[i] == "SWE") { SWE_color = visaFree4color; }
            if (visaFreeCountries[i] == "CHE") { CHE_color = visaFree4color; }
            if (visaFreeCountries[i] == "SYR") { SYR_color = visaFree4color; }
            if (visaFreeCountries[i] == "TWN") { TWN_color = visaFree4color; }
            if (visaFreeCountries[i] == "TJK") { TJK_color = visaFree4color; }
            if (visaFreeCountries[i] == "TZA") { TZA_color = visaFree4color; }
            if (visaFreeCountries[i] == "THA") { THA_color = visaFree4color; }
            if (visaFreeCountries[i] == "TLS") { TLS_color = visaFree4color; }
            if (visaFreeCountries[i] == "TGO") { TGO_color = visaFree4color; }
            if (visaFreeCountries[i] == "TON") { TON_color = visaFree4color; }
            if (visaFreeCountries[i] == "TTO") { TTO_color = visaFree4color; }
            if (visaFreeCountries[i] == "TUN") { TUN_color = visaFree4color; }
            if (visaFreeCountries[i] == "TUR") { TUR_color = visaFree4color; }
            if (visaFreeCountries[i] == "TKM") { TKM_color = visaFree4color; }
            if (visaFreeCountries[i] == "TUV") { TUV_color = visaFree4color; }
            if (visaFreeCountries[i] == "UGA") { UGA_color = visaFree4color; }
            if (visaFreeCountries[i] == "UKR") { UKR_color = visaFree4color; }
            if (visaFreeCountries[i] == "ARE") { ARE_color = visaFree4color; }
            if (visaFreeCountries[i] == "GBR") { GBR_color = visaFree4color; }
            if (visaFreeCountries[i] == "USA") { USA_color = visaFree4color; }
            if (visaFreeCountries[i] == "URY") { URY_color = visaFree4color; }
            if (visaFreeCountries[i] == "UZB") { UZB_color = visaFree4color; }
            if (visaFreeCountries[i] == "VUT") { VUT_color = visaFree4color; }
            if (visaFreeCountries[i] == "VEN") { VEN_color = visaFree4color; }
            if (visaFreeCountries[i] == "VNM") { VNM_color = visaFree4color; }
            if (visaFreeCountries[i] == "YEM") { YEM_color = visaFree4color; }
            if (visaFreeCountries[i] == "ZMB") { ZMB_color = visaFree4color; }
            if (visaFreeCountries[i] == "ZWE") { ZWE_color = visaFree4color; }
        }
    }

    public void setColorsCountryItself()
    {
        if (visaItselfIdentified == "AFG") { AFG_color = visaItselfcolor; }
        if (visaItselfIdentified == "ALB") { ALB_color = visaItselfcolor; }
        if (visaItselfIdentified == "DZA") { DZA_color = visaItselfcolor; }
        if (visaItselfIdentified == "AND") { AND_color = visaItselfcolor; }
        if (visaItselfIdentified == "AGO") { AGO_color = visaItselfcolor; }
        if (visaItselfIdentified == "ATG") { ATG_color = visaItselfcolor; }
        if (visaItselfIdentified == "ARG") { ARG_color = visaItselfcolor; }
        if (visaItselfIdentified == "ARM") { ARM_color = visaItselfcolor; }
        if (visaItselfIdentified == "AUS") { AUS_color = visaItselfcolor; }
        if (visaItselfIdentified == "AUT") { AUT_color = visaItselfcolor; }
        if (visaItselfIdentified == "AZE") { AZE_color = visaItselfcolor; }
        if (visaItselfIdentified == "BHS") { BHS_color = visaItselfcolor; }
        if (visaItselfIdentified == "BHR") { BHR_color = visaItselfcolor; }
        if (visaItselfIdentified == "BGD") { BGD_color = visaItselfcolor; }
        if (visaItselfIdentified == "BRB") { BRB_color = visaItselfcolor; }
        if (visaItselfIdentified == "BLR") { BLR_color = visaItselfcolor; }
        if (visaItselfIdentified == "BEL") { BEL_color = visaItselfcolor; }
        if (visaItselfIdentified == "BLZ") { BLZ_color = visaItselfcolor; }
        if (visaItselfIdentified == "BEN") { BEN_color = visaItselfcolor; }
        if (visaItselfIdentified == "BTN") { BTN_color = visaItselfcolor; }
        if (visaItselfIdentified == "BOL") { BOL_color = visaItselfcolor; }
        if (visaItselfIdentified == "BIH") { BIH_color = visaItselfcolor; }
        if (visaItselfIdentified == "BWA") { BWA_color = visaItselfcolor; }
        if (visaItselfIdentified == "BRA") { BRA_color = visaItselfcolor; }
        if (visaItselfIdentified == "BRN") { BRN_color = visaItselfcolor; }
        if (visaItselfIdentified == "BGR") { BGR_color = visaItselfcolor; }
        if (visaItselfIdentified == "BFA") { BFA_color = visaItselfcolor; }
        if (visaItselfIdentified == "BDI") { BDI_color = visaItselfcolor; }
        if (visaItselfIdentified == "KHM") { KHM_color = visaItselfcolor; }
        if (visaItselfIdentified == "CMR") { CMR_color = visaItselfcolor; }
        if (visaItselfIdentified == "CAN") { CAN_color = visaItselfcolor; }
        if (visaItselfIdentified == "CPV") { CPV_color = visaItselfcolor; }
        if (visaItselfIdentified == "CAF") { CAF_color = visaItselfcolor; }
        if (visaItselfIdentified == "TCD") { TCD_color = visaItselfcolor; }
        if (visaItselfIdentified == "CHL") { CHL_color = visaItselfcolor; }
        if (visaItselfIdentified == "CHN") { CHN_color = visaItselfcolor; }
        if (visaItselfIdentified == "COL") { COL_color = visaItselfcolor; }
        if (visaItselfIdentified == "COM") { COM_color = visaItselfcolor; }
        if (visaItselfIdentified == "COG") { COG_color = visaItselfcolor; }
        if (visaItselfIdentified == "COD") { COD_color = visaItselfcolor; }
        if (visaItselfIdentified == "CRI") { CRI_color = visaItselfcolor; }
        if (visaItselfIdentified == "CIV") { CIV_color = visaItselfcolor; }
        if (visaItselfIdentified == "HRV") { HRV_color = visaItselfcolor; }
        if (visaItselfIdentified == "CUB") { CUB_color = visaItselfcolor; }
        if (visaItselfIdentified == "CYP") { CYP_color = visaItselfcolor; }
        if (visaItselfIdentified == "CZE") { CZE_color = visaItselfcolor; }
        if (visaItselfIdentified == "DNK") { DNK_color = visaItselfcolor; }
        if (visaItselfIdentified == "DJI") { DJI_color = visaItselfcolor; }
        if (visaItselfIdentified == "DMA") { DMA_color = visaItselfcolor; }
        if (visaItselfIdentified == "DOM") { DOM_color = visaItselfcolor; }
        if (visaItselfIdentified == "ECU") { ECU_color = visaItselfcolor; }
        if (visaItselfIdentified == "EGY") { EGY_color = visaItselfcolor; }
        if (visaItselfIdentified == "SLV") { SLV_color = visaItselfcolor; }
        if (visaItselfIdentified == "GNQ") { GNQ_color = visaItselfcolor; }
        if (visaItselfIdentified == "ERI") { ERI_color = visaItselfcolor; }
        if (visaItselfIdentified == "EST") { EST_color = visaItselfcolor; }
        if (visaItselfIdentified == "ETH") { ETH_color = visaItselfcolor; }
        if (visaItselfIdentified == "FJI") { FJI_color = visaItselfcolor; }
        if (visaItselfIdentified == "FIN") { FIN_color = visaItselfcolor; }
        if (visaItselfIdentified == "FRA") { FRA_color = visaItselfcolor; }
        if (visaItselfIdentified == "GAB") { GAB_color = visaItselfcolor; }
        if (visaItselfIdentified == "GMB") { GMB_color = visaItselfcolor; }
        if (visaItselfIdentified == "GEO") { GEO_color = visaItselfcolor; }
        if (visaItselfIdentified == "DEU") { DEU_color = visaItselfcolor; }
        if (visaItselfIdentified == "GHA") { GHA_color = visaItselfcolor; }
        if (visaItselfIdentified == "GRC") { GRC_color = visaItselfcolor; }
        if (visaItselfIdentified == "GRD") { GRD_color = visaItselfcolor; }
        if (visaItselfIdentified == "GTM") { GTM_color = visaItselfcolor; }
        if (visaItselfIdentified == "GIN") { GIN_color = visaItselfcolor; }
        if (visaItselfIdentified == "GNB") { GNB_color = visaItselfcolor; }
        if (visaItselfIdentified == "GUY") { GUY_color = visaItselfcolor; }
        if (visaItselfIdentified == "HTI") { HTI_color = visaItselfcolor; }
        if (visaItselfIdentified == "VAT") { VAT_color = visaItselfcolor; }
        if (visaItselfIdentified == "HND") { HND_color = visaItselfcolor; }
        if (visaItselfIdentified == "HKG") { HKG_color = visaItselfcolor; }
        if (visaItselfIdentified == "HUN") { HUN_color = visaItselfcolor; }
        if (visaItselfIdentified == "ISL") { ISL_color = visaItselfcolor; }
        if (visaItselfIdentified == "IND") { IND_color = visaItselfcolor; }
        if (visaItselfIdentified == "IDN") { IDN_color = visaItselfcolor; }
        if (visaItselfIdentified == "IRN") { IRN_color = visaItselfcolor; }
        if (visaItselfIdentified == "IRQ") { IRQ_color = visaItselfcolor; }
        if (visaItselfIdentified == "IRL") { IRL_color = visaItselfcolor; }
        if (visaItselfIdentified == "ISR") { ISR_color = visaItselfcolor; }
        if (visaItselfIdentified == "ITA") { ITA_color = visaItselfcolor; }
        if (visaItselfIdentified == "JAM") { JAM_color = visaItselfcolor; }
        if (visaItselfIdentified == "JPN") { JPN_color = visaItselfcolor; }
        if (visaItselfIdentified == "JOR") { JOR_color = visaItselfcolor; }
        if (visaItselfIdentified == "KAZ") { KAZ_color = visaItselfcolor; }
        if (visaItselfIdentified == "KEN") { KEN_color = visaItselfcolor; }
        if (visaItselfIdentified == "KIR") { KIR_color = visaItselfcolor; }
        if (visaItselfIdentified == "PRK") { PRK_color = visaItselfcolor; }
        if (visaItselfIdentified == "KOR") { KOR_color = visaItselfcolor; }
        if (visaItselfIdentified == "KOS") { KOS_color = visaItselfcolor; }
        if (visaItselfIdentified == "KWT") { KWT_color = visaItselfcolor; }
        if (visaItselfIdentified == "KGZ") { KGZ_color = visaItselfcolor; }
        if (visaItselfIdentified == "LAO") { LAO_color = visaItselfcolor; }
        if (visaItselfIdentified == "LVA") { LVA_color = visaItselfcolor; }
        if (visaItselfIdentified == "LBN") { LBN_color = visaItselfcolor; }
        if (visaItselfIdentified == "LSO") { LSO_color = visaItselfcolor; }
        if (visaItselfIdentified == "LBR") { LBR_color = visaItselfcolor; }
        if (visaItselfIdentified == "LBY") { LBY_color = visaItselfcolor; }
        if (visaItselfIdentified == "LIE") { LIE_color = visaItselfcolor; }
        if (visaItselfIdentified == "LTU") { LTU_color = visaItselfcolor; }
        if (visaItselfIdentified == "LUX") { LUX_color = visaItselfcolor; }
        if (visaItselfIdentified == "MAC") { MAC_color = visaItselfcolor; }
        if (visaItselfIdentified == "MDG") { MDG_color = visaItselfcolor; }
        if (visaItselfIdentified == "MWI") { MWI_color = visaItselfcolor; }
        if (visaItselfIdentified == "MYS") { MYS_color = visaItselfcolor; }
        if (visaItselfIdentified == "MDV") { MDV_color = visaItselfcolor; }
        if (visaItselfIdentified == "MLI") { MLI_color = visaItselfcolor; }
        if (visaItselfIdentified == "MLT") { MLT_color = visaItselfcolor; }
        if (visaItselfIdentified == "MHL") { MHL_color = visaItselfcolor; }
        if (visaItselfIdentified == "MRT") { MRT_color = visaItselfcolor; }
        if (visaItselfIdentified == "MUS") { MUS_color = visaItselfcolor; }
        if (visaItselfIdentified == "MEX") { MEX_color = visaItselfcolor; }
        if (visaItselfIdentified == "FSM") { FSM_color = visaItselfcolor; }
        if (visaItselfIdentified == "MDA") { MDA_color = visaItselfcolor; }
        if (visaItselfIdentified == "MCO") { MCO_color = visaItselfcolor; }
        if (visaItselfIdentified == "MNG") { MNG_color = visaItselfcolor; }
        if (visaItselfIdentified == "MNE") { MNE_color = visaItselfcolor; }
        if (visaItselfIdentified == "MAR") { MAR_color = visaItselfcolor; }
        if (visaItselfIdentified == "MOZ") { MOZ_color = visaItselfcolor; }
        if (visaItselfIdentified == "MMR") { MMR_color = visaItselfcolor; }
        if (visaItselfIdentified == "NAM") { NAM_color = visaItselfcolor; }
        if (visaItselfIdentified == "NRU") { NRU_color = visaItselfcolor; }
        if (visaItselfIdentified == "NPL") { NPL_color = visaItselfcolor; }
        if (visaItselfIdentified == "NLD") { NLD_color = visaItselfcolor; }
        if (visaItselfIdentified == "NZL") { NZL_color = visaItselfcolor; }
        if (visaItselfIdentified == "NIC") { NIC_color = visaItselfcolor; }
        if (visaItselfIdentified == "NER") { NER_color = visaItselfcolor; }
        if (visaItselfIdentified == "NGA") { NGA_color = visaItselfcolor; }
        if (visaItselfIdentified == "MKD") { MKD_color = visaItselfcolor; }
        if (visaItselfIdentified == "NOR") { NOR_color = visaItselfcolor; }
        if (visaItselfIdentified == "OMN") { OMN_color = visaItselfcolor; }
        if (visaItselfIdentified == "PAK") { PAK_color = visaItselfcolor; }
        if (visaItselfIdentified == "PLW") { PLW_color = visaItselfcolor; }
        if (visaItselfIdentified == "PSE") { PSE_color = visaItselfcolor; }
        if (visaItselfIdentified == "PAN") { PAN_color = visaItselfcolor; }
        if (visaItselfIdentified == "PNG") { PNG_color = visaItselfcolor; }
        if (visaItselfIdentified == "PRY") { PRY_color = visaItselfcolor; }
        if (visaItselfIdentified == "PER") { PER_color = visaItselfcolor; }
        if (visaItselfIdentified == "PHL") { PHL_color = visaItselfcolor; }
        if (visaItselfIdentified == "POL") { POL_color = visaItselfcolor; }
        if (visaItselfIdentified == "PRT") { PRT_color = visaItselfcolor; }
        if (visaItselfIdentified == "QAT") { QAT_color = visaItselfcolor; }
        if (visaItselfIdentified == "ROU") { ROU_color = visaItselfcolor; }
        if (visaItselfIdentified == "RUS") { RUS_color = visaItselfcolor; }
        if (visaItselfIdentified == "RWA") { RWA_color = visaItselfcolor; }
        if (visaItselfIdentified == "KNA") { KNA_color = visaItselfcolor; }
        if (visaItselfIdentified == "LCA") { LCA_color = visaItselfcolor; }
        if (visaItselfIdentified == "VCT") { VCT_color = visaItselfcolor; }
        if (visaItselfIdentified == "WSM") { WSM_color = visaItselfcolor; }
        if (visaItselfIdentified == "SMR") { SMR_color = visaItselfcolor; }
        if (visaItselfIdentified == "STP") { STP_color = visaItselfcolor; }
        if (visaItselfIdentified == "SAU") { SAU_color = visaItselfcolor; }
        if (visaItselfIdentified == "SEN") { SEN_color = visaItselfcolor; }
        if (visaItselfIdentified == "SRB") { SRB_color = visaItselfcolor; }
        if (visaItselfIdentified == "SYC") { SYC_color = visaItselfcolor; }
        if (visaItselfIdentified == "SLE") { SLE_color = visaItselfcolor; }
        if (visaItselfIdentified == "SGP") { SGP_color = visaItselfcolor; }
        if (visaItselfIdentified == "SVK") { SVK_color = visaItselfcolor; }
        if (visaItselfIdentified == "SVN") { SVN_color = visaItselfcolor; }
        if (visaItselfIdentified == "SLB") { SLB_color = visaItselfcolor; }
        if (visaItselfIdentified == "SOM") { SOM_color = visaItselfcolor; }
        if (visaItselfIdentified == "ZAF") { ZAF_color = visaItselfcolor; }
        if (visaItselfIdentified == "SSD") { SSD_color = visaItselfcolor; }
        if (visaItselfIdentified == "ESP") { ESP_color = visaItselfcolor; }
        if (visaItselfIdentified == "LKA") { LKA_color = visaItselfcolor; }
        if (visaItselfIdentified == "SDN") { SDN_color = visaItselfcolor; }
        if (visaItselfIdentified == "SUR") { SUR_color = visaItselfcolor; }
        if (visaItselfIdentified == "SWZ") { SWZ_color = visaItselfcolor; }
        if (visaItselfIdentified == "SWE") { SWE_color = visaItselfcolor; }
        if (visaItselfIdentified == "CHE") { CHE_color = visaItselfcolor; }
        if (visaItselfIdentified == "SYR") { SYR_color = visaItselfcolor; }
        if (visaItselfIdentified == "TWN") { TWN_color = visaItselfcolor; }
        if (visaItselfIdentified == "TJK") { TJK_color = visaItselfcolor; }
        if (visaItselfIdentified == "TZA") { TZA_color = visaItselfcolor; }
        if (visaItselfIdentified == "THA") { THA_color = visaItselfcolor; }
        if (visaItselfIdentified == "TLS") { TLS_color = visaItselfcolor; }
        if (visaItselfIdentified == "TGO") { TGO_color = visaItselfcolor; }
        if (visaItselfIdentified == "TON") { TON_color = visaItselfcolor; }
        if (visaItselfIdentified == "TTO") { TTO_color = visaItselfcolor; }
        if (visaItselfIdentified == "TUN") { TUN_color = visaItselfcolor; }
        if (visaItselfIdentified == "TUR") { TUR_color = visaItselfcolor; }
        if (visaItselfIdentified == "TKM") { TKM_color = visaItselfcolor; }
        if (visaItselfIdentified == "TUV") { TUV_color = visaItselfcolor; }
        if (visaItselfIdentified == "UGA") { UGA_color = visaItselfcolor; }
        if (visaItselfIdentified == "UKR") { UKR_color = visaItselfcolor; }
        if (visaItselfIdentified == "ARE") { ARE_color = visaItselfcolor; }
        if (visaItselfIdentified == "GBR") { GBR_color = visaItselfcolor; }
        if (visaItselfIdentified == "USA") { USA_color = visaItselfcolor; }
        if (visaItselfIdentified == "URY") { URY_color = visaItselfcolor; }
        if (visaItselfIdentified == "UZB") { UZB_color = visaItselfcolor; }
        if (visaItselfIdentified == "VUT") { VUT_color = visaItselfcolor; }
        if (visaItselfIdentified == "VEN") { VEN_color = visaItselfcolor; }
        if (visaItselfIdentified == "VNM") { VNM_color = visaItselfcolor; }
        if (visaItselfIdentified == "YEM") { YEM_color = visaItselfcolor; }
        if (visaItselfIdentified == "ZMB") { ZMB_color = visaItselfcolor; }
        if (visaItselfIdentified == "ZWE") { ZWE_color = visaItselfcolor; }
    }

    public void setColorsOnRenderers() //Sets the colors of each country to their renderers.
    {
        AFG_rend.material.SetColor("_Color", AFG_color);
        ALB_rend.material.SetColor("_Color", ALB_color);
        DZA_rend.material.SetColor("_Color", DZA_color);
        AND_rend.material.SetColor("_Color", AND_color);
        AGO_rend.material.SetColor("_Color", AGO_color);
        ATG_rend.material.SetColor("_Color", ATG_color);
        ARG_rend.material.SetColor("_Color", ARG_color);
        ARM_rend.material.SetColor("_Color", ARM_color);
        AUS_rend.material.SetColor("_Color", AUS_color);
        AUT_rend.material.SetColor("_Color", AUT_color);
        AZE_rend.material.SetColor("_Color", AZE_color);
        BHS_rend.material.SetColor("_Color", BHS_color);
        BHR_rend.material.SetColor("_Color", BHR_color);
        BGD_rend.material.SetColor("_Color", BGD_color);
        BRB_rend.material.SetColor("_Color", BRB_color);
        BLR_rend.material.SetColor("_Color", BLR_color);
        BEL_rend.material.SetColor("_Color", BEL_color);
        BLZ_rend.material.SetColor("_Color", BLZ_color);
        BEN_rend.material.SetColor("_Color", BEN_color);
        BTN_rend.material.SetColor("_Color", BTN_color);
        BOL_rend.material.SetColor("_Color", BOL_color);
        BIH_rend.material.SetColor("_Color", BIH_color);
        BWA_rend.material.SetColor("_Color", BWA_color);
        BRA_rend.material.SetColor("_Color", BRA_color);
        BRN_rend.material.SetColor("_Color", BRN_color);
        BGR_rend.material.SetColor("_Color", BGR_color);
        BFA_rend.material.SetColor("_Color", BFA_color);
        BDI_rend.material.SetColor("_Color", BDI_color);
        KHM_rend.material.SetColor("_Color", KHM_color);
        CMR_rend.material.SetColor("_Color", CMR_color);
        CAN_rend.material.SetColor("_Color", CAN_color);
        CPV_rend.material.SetColor("_Color", CPV_color);
        CAF_rend.material.SetColor("_Color", CAF_color);
        TCD_rend.material.SetColor("_Color", TCD_color);
        CHL_rend.material.SetColor("_Color", CHL_color);
        CHN_rend.material.SetColor("_Color", CHN_color);
        COL_rend.material.SetColor("_Color", COL_color);
        COM_rend.material.SetColor("_Color", COM_color);
        COG_rend.material.SetColor("_Color", COG_color);
        COD_rend.material.SetColor("_Color", COD_color);
        CRI_rend.material.SetColor("_Color", CRI_color);
        CIV_rend.material.SetColor("_Color", CIV_color);
        HRV_rend.material.SetColor("_Color", HRV_color);
        CUB_rend.material.SetColor("_Color", CUB_color);
        CYP_rend.material.SetColor("_Color", CYP_color);
        CZE_rend.material.SetColor("_Color", CZE_color);
        DNK_rend.material.SetColor("_Color", DNK_color);
        DJI_rend.material.SetColor("_Color", DJI_color);
        DMA_rend.material.SetColor("_Color", DMA_color);
        DOM_rend.material.SetColor("_Color", DOM_color);
        ECU_rend.material.SetColor("_Color", ECU_color);
        EGY_rend.material.SetColor("_Color", EGY_color);
        SLV_rend.material.SetColor("_Color", SLV_color);
        GNQ_rend.material.SetColor("_Color", GNQ_color);
        ERI_rend.material.SetColor("_Color", ERI_color);
        EST_rend.material.SetColor("_Color", EST_color);
        ETH_rend.material.SetColor("_Color", ETH_color);
        FJI_rend.material.SetColor("_Color", FJI_color);
        FIN_rend.material.SetColor("_Color", FIN_color);
        FRA_rend.material.SetColor("_Color", FRA_color);
        GAB_rend.material.SetColor("_Color", GAB_color);
        GMB_rend.material.SetColor("_Color", GMB_color);
        GEO_rend.material.SetColor("_Color", GEO_color);
        DEU_rend.material.SetColor("_Color", DEU_color);
        GHA_rend.material.SetColor("_Color", GHA_color);
        GRC_rend.material.SetColor("_Color", GRC_color);
        GRD_rend.material.SetColor("_Color", GRD_color);
        GTM_rend.material.SetColor("_Color", GTM_color);
        GIN_rend.material.SetColor("_Color", GIN_color);
        GNB_rend.material.SetColor("_Color", GNB_color);
        GUY_rend.material.SetColor("_Color", GUY_color);
        HTI_rend.material.SetColor("_Color", HTI_color);
        VAT_rend.material.SetColor("_Color", VAT_color);
        HND_rend.material.SetColor("_Color", HND_color);
        HKG_rend.material.SetColor("_Color", HKG_color);
        HUN_rend.material.SetColor("_Color", HUN_color);
        ISL_rend.material.SetColor("_Color", ISL_color);
        IND_rend.material.SetColor("_Color", IND_color);
        IDN_rend.material.SetColor("_Color", IDN_color);
        IRN_rend.material.SetColor("_Color", IRN_color);
        IRQ_rend.material.SetColor("_Color", IRQ_color);
        IRL_rend.material.SetColor("_Color", IRL_color);
        ISR_rend.material.SetColor("_Color", ISR_color);
        ITA_rend.material.SetColor("_Color", ITA_color);
        JAM_rend.material.SetColor("_Color", JAM_color);
        JPN_rend.material.SetColor("_Color", JPN_color);
        JOR_rend.material.SetColor("_Color", JOR_color);
        KAZ_rend.material.SetColor("_Color", KAZ_color);
        KEN_rend.material.SetColor("_Color", KEN_color);
        KIR_rend.material.SetColor("_Color", KIR_color);
        PRK_rend.material.SetColor("_Color", PRK_color);
        KOR_rend.material.SetColor("_Color", KOR_color);
        KOS_rend.material.SetColor("_Color", KOS_color);
        KWT_rend.material.SetColor("_Color", KWT_color);
        KGZ_rend.material.SetColor("_Color", KGZ_color);
        LAO_rend.material.SetColor("_Color", LAO_color);
        LVA_rend.material.SetColor("_Color", LVA_color);
        LBN_rend.material.SetColor("_Color", LBN_color);
        LSO_rend.material.SetColor("_Color", LSO_color);
        LBR_rend.material.SetColor("_Color", LBR_color);
        LBY_rend.material.SetColor("_Color", LBY_color);
        LIE_rend.material.SetColor("_Color", LIE_color);
        LTU_rend.material.SetColor("_Color", LTU_color);
        LUX_rend.material.SetColor("_Color", LUX_color);
        MAC_rend.material.SetColor("_Color", MAC_color);
        MDG_rend.material.SetColor("_Color", MDG_color);
        MWI_rend.material.SetColor("_Color", MWI_color);
        MYS_rend.material.SetColor("_Color", MYS_color);
        MDV_rend.material.SetColor("_Color", MDV_color);
        MLI_rend.material.SetColor("_Color", MLI_color);
        MLT_rend.material.SetColor("_Color", MLT_color);
        MHL_rend.material.SetColor("_Color", MHL_color);
        MRT_rend.material.SetColor("_Color", MRT_color);
        MUS_rend.material.SetColor("_Color", MUS_color);
        MEX_rend.material.SetColor("_Color", MEX_color);
        FSM_rend.material.SetColor("_Color", FSM_color);
        MDA_rend.material.SetColor("_Color", MDA_color);
        MCO_rend.material.SetColor("_Color", MCO_color);
        MNG_rend.material.SetColor("_Color", MNG_color);
        MNE_rend.material.SetColor("_Color", MNE_color);
        MAR_rend.material.SetColor("_Color", MAR_color);
        MOZ_rend.material.SetColor("_Color", MOZ_color);
        MMR_rend.material.SetColor("_Color", MMR_color);
        NAM_rend.material.SetColor("_Color", NAM_color);
        NRU_rend.material.SetColor("_Color", NRU_color);
        NPL_rend.material.SetColor("_Color", NPL_color);
        NLD_rend.material.SetColor("_Color", NLD_color);
        NZL_rend.material.SetColor("_Color", NZL_color);
        NIC_rend.material.SetColor("_Color", NIC_color);
        NER_rend.material.SetColor("_Color", NER_color);
        NGA_rend.material.SetColor("_Color", NGA_color);
        MKD_rend.material.SetColor("_Color", MKD_color);
        NOR_rend.material.SetColor("_Color", NOR_color);
        OMN_rend.material.SetColor("_Color", OMN_color);
        PAK_rend.material.SetColor("_Color", PAK_color);
        PLW_rend.material.SetColor("_Color", PLW_color);
        PSE_rend.material.SetColor("_Color", PSE_color);
        PAN_rend.material.SetColor("_Color", PAN_color);
        PNG_rend.material.SetColor("_Color", PNG_color);
        PRY_rend.material.SetColor("_Color", PRY_color);
        PER_rend.material.SetColor("_Color", PER_color);
        PHL_rend.material.SetColor("_Color", PHL_color);
        POL_rend.material.SetColor("_Color", POL_color);
        PRT_rend.material.SetColor("_Color", PRT_color);
        QAT_rend.material.SetColor("_Color", QAT_color);
        ROU_rend.material.SetColor("_Color", ROU_color);
        RUS_rend.material.SetColor("_Color", RUS_color);
        RWA_rend.material.SetColor("_Color", RWA_color);
        KNA_rend.material.SetColor("_Color", KNA_color);
        LCA_rend.material.SetColor("_Color", LCA_color);
        VCT_rend.material.SetColor("_Color", VCT_color);
        WSM_rend.material.SetColor("_Color", WSM_color);
        SMR_rend.material.SetColor("_Color", SMR_color);
        STP_rend.material.SetColor("_Color", STP_color);
        SAU_rend.material.SetColor("_Color", SAU_color);
        SEN_rend.material.SetColor("_Color", SEN_color);
        SRB_rend.material.SetColor("_Color", SRB_color);
        SYC_rend.material.SetColor("_Color", SYC_color);
        SLE_rend.material.SetColor("_Color", SLE_color);
        SGP_rend.material.SetColor("_Color", SGP_color);
        SVK_rend.material.SetColor("_Color", SVK_color);
        SVN_rend.material.SetColor("_Color", SVN_color);
        SLB_rend.material.SetColor("_Color", SLB_color);
        SOM_rend.material.SetColor("_Color", SOM_color);
        ZAF_rend.material.SetColor("_Color", ZAF_color);
        SSD_rend.material.SetColor("_Color", SSD_color);
        ESP_rend.material.SetColor("_Color", ESP_color);
        LKA_rend.material.SetColor("_Color", LKA_color);
        SDN_rend.material.SetColor("_Color", SDN_color);
        SUR_rend.material.SetColor("_Color", SUR_color);
        SWZ_rend.material.SetColor("_Color", SWZ_color);
        SWE_rend.material.SetColor("_Color", SWE_color);
        CHE_rend.material.SetColor("_Color", CHE_color);
        SYR_rend.material.SetColor("_Color", SYR_color);
        TWN_rend.material.SetColor("_Color", TWN_color);
        TJK_rend.material.SetColor("_Color", TJK_color);
        TZA_rend.material.SetColor("_Color", TZA_color);
        THA_rend.material.SetColor("_Color", THA_color);
        TLS_rend.material.SetColor("_Color", TLS_color);
        TGO_rend.material.SetColor("_Color", TGO_color);
        TON_rend.material.SetColor("_Color", TON_color);
        TTO_rend.material.SetColor("_Color", TTO_color);
        TUN_rend.material.SetColor("_Color", TUN_color);
        TUR_rend.material.SetColor("_Color", TUR_color);
        TKM_rend.material.SetColor("_Color", TKM_color);
        TUV_rend.material.SetColor("_Color", TUV_color);
        UGA_rend.material.SetColor("_Color", UGA_color);
        UKR_rend.material.SetColor("_Color", UKR_color);
        ARE_rend.material.SetColor("_Color", ARE_color);
        GBR_rend.material.SetColor("_Color", GBR_color);
        USA_rend.material.SetColor("_Color", USA_color);
        URY_rend.material.SetColor("_Color", URY_color);
        UZB_rend.material.SetColor("_Color", UZB_color);
        VUT_rend.material.SetColor("_Color", VUT_color);
        VEN_rend.material.SetColor("_Color", VEN_color);
        VNM_rend.material.SetColor("_Color", VNM_color);
        YEM_rend.material.SetColor("_Color", YEM_color);
        ZMB_rend.material.SetColor("_Color", ZMB_color);
        ZWE_rend.material.SetColor("_Color", ZWE_color);

        //COUNTRIES WITH MULTIPLE PIECES
        CHN2_rend.material.SetColor("_Color", CHN_color);
        DNK2_rend.material.SetColor("_Color", DNK_color);
        MYS2_rend.material.SetColor("_Color", MYS_color);
        GBR2_rend.material.SetColor("_Color", GBR_color);
        GRC2_rend.material.SetColor("_Color", GRC_color);
        JPN2_rend.material.SetColor("_Color", JPN_color);
        IND2_rend.material.SetColor("_Color", IDN_color);
        IND3_rend.material.SetColor("_Color", IDN_color);
        IND4_rend.material.SetColor("_Color", IDN_color);
        IND5_rend.material.SetColor("_Color", IDN_color);
        IND6_rend.material.SetColor("_Color", IDN_color);
        IND7_rend.material.SetColor("_Color", IDN_color);
        PHL2_rend.material.SetColor("_Color", PHL_color);
        AUS2_rend.material.SetColor("_Color", AUS_color);
        CAN2_rend.material.SetColor("_Color", CAN_color);
        NZL2_rend.material.SetColor("_Color", NZL_color);
        USA2_rend.material.SetColor("_Color", USA_color);
        USA3_rend.material.SetColor("_Color", USA_color);
    }

    public void getRenderers()
    {
        rend = GetComponent<Renderer>();
        AFG_rend = AFG.GetComponent<Renderer>();
        ALB_rend = ALB.GetComponent<Renderer>();
        DZA_rend = DZA.GetComponent<Renderer>();
        AND_rend = AND.GetComponent<Renderer>();
        AGO_rend = AGO.GetComponent<Renderer>();
        ATG_rend = ATG.GetComponent<Renderer>();
        ARG_rend = ARG.GetComponent<Renderer>();
        ARM_rend = ARM.GetComponent<Renderer>();
        AUS_rend = AUS.GetComponent<Renderer>();
        AUT_rend = AUT.GetComponent<Renderer>();
        AZE_rend = AZE.GetComponent<Renderer>();
        BHS_rend = BHS.GetComponent<Renderer>();
        BHR_rend = BHR.GetComponent<Renderer>();
        BGD_rend = BGD.GetComponent<Renderer>();
        BRB_rend = BRB.GetComponent<Renderer>();
        BLR_rend = BLR.GetComponent<Renderer>();
        BEL_rend = BEL.GetComponent<Renderer>();
        BLZ_rend = BLZ.GetComponent<Renderer>();
        BEN_rend = BEN.GetComponent<Renderer>();
        BTN_rend = BTN.GetComponent<Renderer>();
        BOL_rend = BOL.GetComponent<Renderer>();
        BIH_rend = BIH.GetComponent<Renderer>();
        BWA_rend = BWA.GetComponent<Renderer>();
        BRA_rend = BRA.GetComponent<Renderer>();
        BRN_rend = BRN.GetComponent<Renderer>();
        BGR_rend = BGR.GetComponent<Renderer>();
        BFA_rend = BFA.GetComponent<Renderer>();
        BDI_rend = BDI.GetComponent<Renderer>();
        KHM_rend = KHM.GetComponent<Renderer>();
        CMR_rend = CMR.GetComponent<Renderer>();
        CAN_rend = CAN.GetComponent<Renderer>();
        CPV_rend = CPV.GetComponent<Renderer>();
        CAF_rend = CAF.GetComponent<Renderer>();
        TCD_rend = TCD.GetComponent<Renderer>();
        CHL_rend = CHL.GetComponent<Renderer>();
        CHN_rend = CHN.GetComponent<Renderer>();
        COL_rend = COL.GetComponent<Renderer>();
        COM_rend = COM.GetComponent<Renderer>();
        COG_rend = COG.GetComponent<Renderer>();
        COD_rend = COD.GetComponent<Renderer>();
        CRI_rend = CRI.GetComponent<Renderer>();
        CIV_rend = CIV.GetComponent<Renderer>();
        HRV_rend = HRV.GetComponent<Renderer>();
        CUB_rend = CUB.GetComponent<Renderer>();
        CYP_rend = CYP.GetComponent<Renderer>();
        CZE_rend = CZE.GetComponent<Renderer>();
        DNK_rend = DNK.GetComponent<Renderer>();
        DJI_rend = DJI.GetComponent<Renderer>();
        DMA_rend = DMA.GetComponent<Renderer>();
        DOM_rend = DOM.GetComponent<Renderer>();
        ECU_rend = ECU.GetComponent<Renderer>();
        EGY_rend = EGY.GetComponent<Renderer>();
        SLV_rend = SLV.GetComponent<Renderer>();
        GNQ_rend = GNQ.GetComponent<Renderer>();
        ERI_rend = ERI.GetComponent<Renderer>();
        EST_rend = EST.GetComponent<Renderer>();
        ETH_rend = ETH.GetComponent<Renderer>();
        FJI_rend = FJI.GetComponent<Renderer>();
        FIN_rend = FIN.GetComponent<Renderer>();
        FRA_rend = FRA.GetComponent<Renderer>();
        GAB_rend = GAB.GetComponent<Renderer>();
        GMB_rend = GMB.GetComponent<Renderer>();
        GEO_rend = GEO.GetComponent<Renderer>();
        DEU_rend = DEU.GetComponent<Renderer>();
        GHA_rend = GHA.GetComponent<Renderer>();
        GRC_rend = GRC.GetComponent<Renderer>();
        GRD_rend = GRD.GetComponent<Renderer>();
        GTM_rend = GTM.GetComponent<Renderer>();
        GIN_rend = GIN.GetComponent<Renderer>();
        GNB_rend = GNB.GetComponent<Renderer>();
        GUY_rend = GUY.GetComponent<Renderer>();
        HTI_rend = HTI.GetComponent<Renderer>();
        VAT_rend = VAT.GetComponent<Renderer>();
        HND_rend = HND.GetComponent<Renderer>();
        HKG_rend = HKG.GetComponent<Renderer>();
        HUN_rend = HUN.GetComponent<Renderer>();
        ISL_rend = ISL.GetComponent<Renderer>();
        IND_rend = IND.GetComponent<Renderer>();
        IDN_rend = IDN.GetComponent<Renderer>();
        IRN_rend = IRN.GetComponent<Renderer>();
        IRQ_rend = IRQ.GetComponent<Renderer>();
        IRL_rend = IRL.GetComponent<Renderer>();
        ISR_rend = ISR.GetComponent<Renderer>();
        ITA_rend = ITA.GetComponent<Renderer>();
        JAM_rend = JAM.GetComponent<Renderer>();
        JPN_rend = JPN.GetComponent<Renderer>();
        JOR_rend = JOR.GetComponent<Renderer>();
        KAZ_rend = KAZ.GetComponent<Renderer>();
        KEN_rend = KEN.GetComponent<Renderer>();
        KIR_rend = KIR.GetComponent<Renderer>();
        PRK_rend = PRK.GetComponent<Renderer>();
        KOR_rend = KOR.GetComponent<Renderer>();
        KOS_rend = KOS.GetComponent<Renderer>();
        KWT_rend = KWT.GetComponent<Renderer>();
        KGZ_rend = KGZ.GetComponent<Renderer>();
        LAO_rend = LAO.GetComponent<Renderer>();
        LVA_rend = LVA.GetComponent<Renderer>();
        LBN_rend = LBN.GetComponent<Renderer>();
        LSO_rend = LSO.GetComponent<Renderer>();
        LBR_rend = LBR.GetComponent<Renderer>();
        LBY_rend = LBY.GetComponent<Renderer>();
        LIE_rend = LIE.GetComponent<Renderer>();
        LTU_rend = LTU.GetComponent<Renderer>();
        LUX_rend = LUX.GetComponent<Renderer>();
        MAC_rend = MAC.GetComponent<Renderer>();
        MDG_rend = MDG.GetComponent<Renderer>();
        MWI_rend = MWI.GetComponent<Renderer>();
        MYS_rend = MYS.GetComponent<Renderer>();
        MDV_rend = MDV.GetComponent<Renderer>();
        MLI_rend = MLI.GetComponent<Renderer>();
        MLT_rend = MLT.GetComponent<Renderer>();
        MHL_rend = MHL.GetComponent<Renderer>();
        MRT_rend = MRT.GetComponent<Renderer>();
        MUS_rend = MUS.GetComponent<Renderer>();
        MEX_rend = MEX.GetComponent<Renderer>();
        FSM_rend = FSM.GetComponent<Renderer>();
        MDA_rend = MDA.GetComponent<Renderer>();
        MCO_rend = MCO.GetComponent<Renderer>();
        MNG_rend = MNG.GetComponent<Renderer>();
        MNE_rend = MNE.GetComponent<Renderer>();
        MAR_rend = MAR.GetComponent<Renderer>();
        MOZ_rend = MOZ.GetComponent<Renderer>();
        MMR_rend = MMR.GetComponent<Renderer>();
        NAM_rend = NAM.GetComponent<Renderer>();
        NRU_rend = NRU.GetComponent<Renderer>();
        NPL_rend = NPL.GetComponent<Renderer>();
        NLD_rend = NLD.GetComponent<Renderer>();
        NZL_rend = NZL.GetComponent<Renderer>();
        NIC_rend = NIC.GetComponent<Renderer>();
        NER_rend = NER.GetComponent<Renderer>();
        NGA_rend = NGA.GetComponent<Renderer>();
        MKD_rend = MKD.GetComponent<Renderer>();
        NOR_rend = NOR.GetComponent<Renderer>();
        OMN_rend = OMN.GetComponent<Renderer>();
        PAK_rend = PAK.GetComponent<Renderer>();
        PLW_rend = PLW.GetComponent<Renderer>();
        PSE_rend = PSE.GetComponent<Renderer>();
        PAN_rend = PAN.GetComponent<Renderer>();
        PNG_rend = PNG.GetComponent<Renderer>();
        PRY_rend = PRY.GetComponent<Renderer>();
        PER_rend = PER.GetComponent<Renderer>();
        PHL_rend = PHL.GetComponent<Renderer>();
        POL_rend = POL.GetComponent<Renderer>();
        PRT_rend = PRT.GetComponent<Renderer>();
        QAT_rend = QAT.GetComponent<Renderer>();
        ROU_rend = ROU.GetComponent<Renderer>();
        RUS_rend = RUS.GetComponent<Renderer>();
        RWA_rend = RWA.GetComponent<Renderer>();
        KNA_rend = KNA.GetComponent<Renderer>();
        LCA_rend = LCA.GetComponent<Renderer>();
        VCT_rend = VCT.GetComponent<Renderer>();
        WSM_rend = WSM.GetComponent<Renderer>();
        SMR_rend = SMR.GetComponent<Renderer>();
        STP_rend = STP.GetComponent<Renderer>();
        SAU_rend = SAU.GetComponent<Renderer>();
        SEN_rend = SEN.GetComponent<Renderer>();
        SRB_rend = SRB.GetComponent<Renderer>();
        SYC_rend = SYC.GetComponent<Renderer>();
        SLE_rend = SLE.GetComponent<Renderer>();
        SGP_rend = SGP.GetComponent<Renderer>();
        SVK_rend = SVK.GetComponent<Renderer>();
        SVN_rend = SVN.GetComponent<Renderer>();
        SLB_rend = SLB.GetComponent<Renderer>();
        SOM_rend = SOM.GetComponent<Renderer>();
        ZAF_rend = ZAF.GetComponent<Renderer>();
        SSD_rend = SSD.GetComponent<Renderer>();
        ESP_rend = ESP.GetComponent<Renderer>();
        LKA_rend = LKA.GetComponent<Renderer>();
        SDN_rend = SDN.GetComponent<Renderer>();
        SUR_rend = SUR.GetComponent<Renderer>();
        SWZ_rend = SWZ.GetComponent<Renderer>();
        SWE_rend = SWE.GetComponent<Renderer>();
        CHE_rend = CHE.GetComponent<Renderer>();
        SYR_rend = SYR.GetComponent<Renderer>();
        TWN_rend = TWN.GetComponent<Renderer>();
        TJK_rend = TJK.GetComponent<Renderer>();
        TZA_rend = TZA.GetComponent<Renderer>();
        THA_rend = THA.GetComponent<Renderer>();
        TLS_rend = TLS.GetComponent<Renderer>();
        TGO_rend = TGO.GetComponent<Renderer>();
        TON_rend = TON.GetComponent<Renderer>();
        TTO_rend = TTO.GetComponent<Renderer>();
        TUN_rend = TUN.GetComponent<Renderer>();
        TUR_rend = TUR.GetComponent<Renderer>();
        TKM_rend = TKM.GetComponent<Renderer>();
        TUV_rend = TUV.GetComponent<Renderer>();
        UGA_rend = UGA.GetComponent<Renderer>();
        UKR_rend = UKR.GetComponent<Renderer>();
        ARE_rend = ARE.GetComponent<Renderer>();
        GBR_rend = GBR.GetComponent<Renderer>();
        USA_rend = USA.GetComponent<Renderer>();
        URY_rend = URY.GetComponent<Renderer>();
        UZB_rend = UZB.GetComponent<Renderer>();
        VUT_rend = VUT.GetComponent<Renderer>();
        VEN_rend = VEN.GetComponent<Renderer>();
        VNM_rend = VNM.GetComponent<Renderer>();
        YEM_rend = YEM.GetComponent<Renderer>();
        ZMB_rend = ZMB.GetComponent<Renderer>();
        ZWE_rend = ZWE.GetComponent<Renderer>();

        //COUNTRIES WITH MULTIPLE MESHES 
        CHN2_rend = CHN2.GetComponent<Renderer>();
        DNK2_rend = DNK2.GetComponent<Renderer>();
        MYS2_rend = MYS2.GetComponent<Renderer>();
        GBR2_rend = GBR2.GetComponent<Renderer>();
        GRC2_rend = GRC2.GetComponent<Renderer>();
        JPN2_rend = JPN2.GetComponent<Renderer>();
        IND2_rend = IND2.GetComponent<Renderer>();
        IND3_rend = IND3.GetComponent<Renderer>();
        IND4_rend = IND4.GetComponent<Renderer>();
        IND5_rend = IND5.GetComponent<Renderer>();
        IND6_rend = IND6.GetComponent<Renderer>();
        IND7_rend = IND7.GetComponent<Renderer>();
        PHL2_rend = PHL2.GetComponent<Renderer>();
        AUS2_rend = AUS2.GetComponent<Renderer>();
        CAN2_rend = CAN2.GetComponent<Renderer>();
        NZL2_rend = NZL2.GetComponent<Renderer>();
        USA2_rend = USA2.GetComponent<Renderer>();
        USA3_rend = USA3.GetComponent<Renderer>();
    }

    public void setDefaultColor()
    {
        AFG_color = DefaultColor;
        ALB_color = DefaultColor;
        DZA_color = DefaultColor;
        AND_color = DefaultColor;
        AGO_color = DefaultColor;
        ATG_color = DefaultColor;
        ARG_color = DefaultColor;
        ARM_color = DefaultColor;
        AUS_color = DefaultColor;
        AUT_color = DefaultColor;
        AZE_color = DefaultColor;
        BHS_color = DefaultColor;
        BHR_color = DefaultColor;
        BGD_color = DefaultColor;
        BRB_color = DefaultColor;
        BLR_color = DefaultColor;
        BEL_color = DefaultColor;
        BLZ_color = DefaultColor;
        BEN_color = DefaultColor;
        BTN_color = DefaultColor;
        BOL_color = DefaultColor;
        BIH_color = DefaultColor;
        BWA_color = DefaultColor;
        BRA_color = DefaultColor;
        BRN_color = DefaultColor;
        BGR_color = DefaultColor;
        BFA_color = DefaultColor;
        BDI_color = DefaultColor;
        KHM_color = DefaultColor;
        CMR_color = DefaultColor;
        CAN_color = DefaultColor;
        CPV_color = DefaultColor;
        CAF_color = DefaultColor;
        TCD_color = DefaultColor;
        CHL_color = DefaultColor;
        CHN_color = DefaultColor;
        COL_color = DefaultColor;
        COM_color = DefaultColor;
        COG_color = DefaultColor;
        COD_color = DefaultColor;
        CRI_color = DefaultColor;
        CIV_color = DefaultColor;
        HRV_color = DefaultColor;
        CUB_color = DefaultColor;
        CYP_color = DefaultColor;
        CZE_color = DefaultColor;
        DNK_color = DefaultColor;
        DJI_color = DefaultColor;
        DMA_color = DefaultColor;
        DOM_color = DefaultColor;
        ECU_color = DefaultColor;
        EGY_color = DefaultColor;
        SLV_color = DefaultColor;
        GNQ_color = DefaultColor;
        ERI_color = DefaultColor;
        EST_color = DefaultColor;
        ETH_color = DefaultColor;
        FJI_color = DefaultColor;
        FIN_color = DefaultColor;
        FRA_color = DefaultColor;
        GAB_color = DefaultColor;
        GMB_color = DefaultColor;
        GEO_color = DefaultColor;
        DEU_color = DefaultColor;
        GHA_color = DefaultColor;
        GRC_color = DefaultColor;
        GRD_color = DefaultColor;
        GTM_color = DefaultColor;
        GIN_color = DefaultColor;
        GNB_color = DefaultColor;
        GUY_color = DefaultColor;
        HTI_color = DefaultColor;
        VAT_color = DefaultColor;
        HND_color = DefaultColor;
        HKG_color = DefaultColor;
        HUN_color = DefaultColor;
        ISL_color = DefaultColor;
        IND_color = DefaultColor;
        IDN_color = DefaultColor;
        IRN_color = DefaultColor;
        IRQ_color = DefaultColor;
        IRL_color = DefaultColor;
        ISR_color = DefaultColor;
        ITA_color = DefaultColor;
        JAM_color = DefaultColor;
        JPN_color = DefaultColor;
        JOR_color = DefaultColor;
        KAZ_color = DefaultColor;
        KEN_color = DefaultColor;
        KIR_color = DefaultColor;
        PRK_color = DefaultColor;
        KOR_color = DefaultColor;
        KOS_color = DefaultColor;
        KWT_color = DefaultColor;
        KGZ_color = DefaultColor;
        LAO_color = DefaultColor;
        LVA_color = DefaultColor;
        LBN_color = DefaultColor;
        LSO_color = DefaultColor;
        LBR_color = DefaultColor;
        LBY_color = DefaultColor;
        LIE_color = DefaultColor;
        LTU_color = DefaultColor;
        LUX_color = DefaultColor;
        MAC_color = DefaultColor;
        MDG_color = DefaultColor;
        MWI_color = DefaultColor;
        MYS_color = DefaultColor;
        MDV_color = DefaultColor;
        MLI_color = DefaultColor;
        MLT_color = DefaultColor;
        MHL_color = DefaultColor;
        MRT_color = DefaultColor;
        MUS_color = DefaultColor;
        MEX_color = DefaultColor;
        FSM_color = DefaultColor;
        MDA_color = DefaultColor;
        MCO_color = DefaultColor;
        MNG_color = DefaultColor;
        MNE_color = DefaultColor;
        MAR_color = DefaultColor;
        MOZ_color = DefaultColor;
        MMR_color = DefaultColor;
        NAM_color = DefaultColor;
        NRU_color = DefaultColor;
        NPL_color = DefaultColor;
        NLD_color = DefaultColor;
        NZL_color = DefaultColor;
        NIC_color = DefaultColor;
        NER_color = DefaultColor;
        NGA_color = DefaultColor;
        MKD_color = DefaultColor;
        NOR_color = DefaultColor;
        OMN_color = DefaultColor;
        PAK_color = DefaultColor;
        PLW_color = DefaultColor;
        PSE_color = DefaultColor;
        PAN_color = DefaultColor;
        PNG_color = DefaultColor;
        PRY_color = DefaultColor;
        PER_color = DefaultColor;
        PHL_color = DefaultColor;
        POL_color = DefaultColor;
        PRT_color = DefaultColor;
        QAT_color = DefaultColor;
        ROU_color = DefaultColor;
        RUS_color = DefaultColor;
        RWA_color = DefaultColor;
        KNA_color = DefaultColor;
        LCA_color = DefaultColor;
        VCT_color = DefaultColor;
        WSM_color = DefaultColor;
        SMR_color = DefaultColor;
        STP_color = DefaultColor;
        SAU_color = DefaultColor;
        SEN_color = DefaultColor;
        SRB_color = DefaultColor;
        SYC_color = DefaultColor;
        SLE_color = DefaultColor;
        SGP_color = DefaultColor;
        SVK_color = DefaultColor;
        SVN_color = DefaultColor;
        SLB_color = DefaultColor;
        SOM_color = DefaultColor;
        ZAF_color = DefaultColor;
        SSD_color = DefaultColor;
        ESP_color = DefaultColor;
        LKA_color = DefaultColor;
        SDN_color = DefaultColor;
        SUR_color = DefaultColor;
        SWZ_color = DefaultColor;
        SWE_color = DefaultColor;
        CHE_color = DefaultColor;
        SYR_color = DefaultColor;
        TWN_color = DefaultColor;
        TJK_color = DefaultColor;
        TZA_color = DefaultColor;
        THA_color = DefaultColor;
        TLS_color = DefaultColor;
        TGO_color = DefaultColor;
        TON_color = DefaultColor;
        TTO_color = DefaultColor;
        TUN_color = DefaultColor;
        TUR_color = DefaultColor;
        TKM_color = DefaultColor;
        TUV_color = DefaultColor;
        UGA_color = DefaultColor;
        UKR_color = DefaultColor;
        ARE_color = DefaultColor;
        GBR_color = DefaultColor;
        USA_color = DefaultColor;
        URY_color = DefaultColor;
        UZB_color = DefaultColor;
        VUT_color = DefaultColor;
        VEN_color = DefaultColor;
        VNM_color = DefaultColor;
        YEM_color = DefaultColor;
        ZMB_color = DefaultColor;
        ZWE_color = DefaultColor;
    }
}
