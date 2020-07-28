using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nonARTextSwap : MonoBehaviour
{
    public Text swaptext;
    private ChangeSceneOnCountryTouch ChangeSceneOnCountryTouchContr;
    private EarthMeshController EarthMeshContr;
    private PassportIdentDict PassportIdentDictContr;
    public string detectedCountryName;
    public string printableCountryName = "EMPTY";
    public List<int> detectedDataList;
    private string printDebugString = "";
    private string seperator = ", ";
    private int catchedClickedIntDebug;
    private string preQselected;

    public void Awake()
    {
        ChangeSceneOnCountryTouchContr = GameObject.FindObjectOfType<ChangeSceneOnCountryTouch>();
        EarthMeshContr = GameObject.FindObjectOfType<EarthMeshController>();
        PassportIdentDictContr = GameObject.FindObjectOfType<PassportIdentDict>();
    }

    public void Start()
    {

        detectedDataList = EarthMeshContr.sendDataList();
        for (int i = 0; i < detectedDataList.Count; i++)
        {
            printDebugString += detectedDataList[i].ToString();
        }
        detectedCountryName = ChangeSceneOnCountryTouchContr.catchClickedCountry();
        detectedCountryToPrintableName();
        preQselected = PlayerPrefs.GetString("PreQ5Ans");
        swaptext.text = preQselected.ToString();
    }

    void Update()
    {
        detectedCountryName = ChangeSceneOnCountryTouchContr.catchClickedCountry();
        detectedCountryToPrintableName();     

        if (detectedCountryName == "EMPTY" || detectedCountryName == "EARTH_MESH" || detectedCountryName == "EARTH_MESH_map")
        {
        } else
        {
           swaptext.text = printableCountryName;
        }
            
        if (Input.GetMouseButtonDown(0))
        {
            detectedDataList = EarthMeshContr.sendDataList();

            for (int i = 0; i < detectedDataList.Count; i++)
            {
                printDebugString += detectedDataList[i].ToString();
            }
        } 
    }

    void detectedCountryToPrintableName() //Convert detectedCountryName Three Letters to Readable Countryname
    {
        if (detectedCountryName == "AND") { printableCountryName = "Andorra"; }
        if (detectedCountryName == "ARE") { printableCountryName = "United Arab Emirates"; }
        if (detectedCountryName == "AFG") { printableCountryName = "Afghanistan"; }
        if (detectedCountryName == "ATG") { printableCountryName = "Antigua & Barbuda"; }
        if (detectedCountryName == "ALB") { printableCountryName = "Albania"; }
        if (detectedCountryName == "ARM") { printableCountryName = "Armenia"; }
        if (detectedCountryName == "AGO") { printableCountryName = "Angola"; }
        if (detectedCountryName == "ARG") { printableCountryName = "Argentina"; }
        if (detectedCountryName == "AUT") { printableCountryName = "Austria"; }
        if (detectedCountryName == "AUS") { printableCountryName = "Australia"; }
        if (detectedCountryName == "AZE") { printableCountryName = "Azerbaijan"; }
        if (detectedCountryName == "BIH") { printableCountryName = "Bosnia & Herzegovina"; }
        if (detectedCountryName == "BRB") { printableCountryName = "Barbados"; }
        if (detectedCountryName == "BGD") { printableCountryName = "Bangladesh"; }
        if (detectedCountryName == "BEL") { printableCountryName = "Belgium"; }
        if (detectedCountryName == "BFA") { printableCountryName = "Burkina Faso"; }
        if (detectedCountryName == "BGR") { printableCountryName = "Bulgaria"; }
        if (detectedCountryName == "BHR") { printableCountryName = "Bahrain"; }
        if (detectedCountryName == "BDI") { printableCountryName = "Burundi"; }
        if (detectedCountryName == "BEN") { printableCountryName = "Benin"; }
        if (detectedCountryName == "BRN") { printableCountryName = "Brunei"; }
        if (detectedCountryName == "BOL") { printableCountryName = "Bolivia"; }
        if (detectedCountryName == "BRA") { printableCountryName = "Brazil"; }
        if (detectedCountryName == "BHS") { printableCountryName = "Bahamas"; }
        if (detectedCountryName == "BTN") { printableCountryName = "Bhutan"; }
        if (detectedCountryName == "BWA") { printableCountryName = "Botswana"; }
        if (detectedCountryName == "BLR") { printableCountryName = "Belarus"; }
        if (detectedCountryName == "BLZ") { printableCountryName = "Belize"; }
        if (detectedCountryName == "CAN") { printableCountryName = "Canada"; }
        if (detectedCountryName == "COD") { printableCountryName = "DR Congo"; }
        if (detectedCountryName == "CAF") { printableCountryName = "Central African Republic"; }
        if (detectedCountryName == "COG") { printableCountryName = "Congo"; }
        if (detectedCountryName == "CHE") { printableCountryName = "Switzerland"; }
        if (detectedCountryName == "CIV") { printableCountryName = "Coted'Ivoire"; }
        if (detectedCountryName == "CHL") { printableCountryName = "Chile"; }
        if (detectedCountryName == "CMR") { printableCountryName = "Cameroon"; }
        if (detectedCountryName == "CHN") { printableCountryName = "China"; }
        if (detectedCountryName == "COL") { printableCountryName = "Colombia"; }
        if (detectedCountryName == "CRI") { printableCountryName = "Costa Rica"; }
        if (detectedCountryName == "CUB") { printableCountryName = "Cuba"; }
        if (detectedCountryName == "CPV") { printableCountryName = "Cape Verde"; }
        if (detectedCountryName == "CYP") { printableCountryName = "Cyprus"; }
        if (detectedCountryName == "CZE") { printableCountryName = "Czech Republic"; }
        if (detectedCountryName == "DEU") { printableCountryName = "Germany"; }
        if (detectedCountryName == "DJI") { printableCountryName = "Djibouti"; }
        if (detectedCountryName == "DNK") { printableCountryName = "Denmark"; }
        if (detectedCountryName == "DMA") { printableCountryName = "Dominica"; }
        if (detectedCountryName == "DOM") { printableCountryName = "Dominican Republic"; }
        if (detectedCountryName == "DZA") { printableCountryName = "Algeria"; }
        if (detectedCountryName == "ECU") { printableCountryName = "Ecuador"; }
        if (detectedCountryName == "EST") { printableCountryName = "Estonia"; }
        if (detectedCountryName == "EGY") { printableCountryName = "Egypt"; }
        if (detectedCountryName == "ERI") { printableCountryName = "Eritrea"; }
        if (detectedCountryName == "ESP") { printableCountryName = "Spain"; }
        if (detectedCountryName == "ETH") { printableCountryName = "Ethiopia"; }
        if (detectedCountryName == "FIN") { printableCountryName = "Finland"; }
        if (detectedCountryName == "FJI") { printableCountryName = "Fiji"; }
        if (detectedCountryName == "FSM") { printableCountryName = "Micronesia"; }
        if (detectedCountryName == "FRA") { printableCountryName = "France"; }
        if (detectedCountryName == "GAB") { printableCountryName = "Gabon"; }
        if (detectedCountryName == "GBR") { printableCountryName = "United Kingdom"; }
        if (detectedCountryName == "GRD") { printableCountryName = "Grenada"; }
        if (detectedCountryName == "GEO") { printableCountryName = "Georgia"; }
        if (detectedCountryName == "GHA") { printableCountryName = "Ghana"; }
        if (detectedCountryName == "GMB") { printableCountryName = "Gambia"; }
        if (detectedCountryName == "GIN") { printableCountryName = "Guinea"; }
        if (detectedCountryName == "GNQ") { printableCountryName = "Equatorial Guinea"; }
        if (detectedCountryName == "GRC") { printableCountryName = "Greece"; }
        if (detectedCountryName == "GTM") { printableCountryName = "Guatemala"; }
        if (detectedCountryName == "GNB") { printableCountryName = "Guinea-Bissau"; }
        if (detectedCountryName == "GUY") { printableCountryName = "Guyana"; }
        if (detectedCountryName == "HKG") { printableCountryName = "Hong Kong"; }
        if (detectedCountryName == "HND") { printableCountryName = "Honduras"; }
        if (detectedCountryName == "HRV") { printableCountryName = "Croatia"; }
        if (detectedCountryName == "HTI") { printableCountryName = "Haiti"; }
        if (detectedCountryName == "HUN") { printableCountryName = "Hungary"; }
        if (detectedCountryName == "IDN") { printableCountryName = "Indonesia"; }
        if (detectedCountryName == "IRL") { printableCountryName = "Ireland"; }
        if (detectedCountryName == "ISR") { printableCountryName = "Israel"; }
        if (detectedCountryName == "IND") { printableCountryName = "India"; }
        if (detectedCountryName == "IRQ") { printableCountryName = "Iraq"; }
        if (detectedCountryName == "IRN") { printableCountryName = "Iran"; }
        if (detectedCountryName == "ISL") { printableCountryName = "Iceland"; }
        if (detectedCountryName == "ITA") { printableCountryName = "Italy"; }
        if (detectedCountryName == "JAM") { printableCountryName = "Jamaica"; }
        if (detectedCountryName == "JOR") { printableCountryName = "Jordan"; }
        if (detectedCountryName == "JPN") { printableCountryName = "Japan"; }
        if (detectedCountryName == "KEN") { printableCountryName = "Kenya"; }
        if (detectedCountryName == "KGZ") { printableCountryName = "Kyrgyzstan"; }
        if (detectedCountryName == "KHM") { printableCountryName = "Cambodia"; }
        if (detectedCountryName == "KIR") { printableCountryName = "Kiribati"; }
        if (detectedCountryName == "COM") { printableCountryName = "Comoros"; }
        if (detectedCountryName == "KNA") { printableCountryName = "St Kitts & Nevis"; }
        if (detectedCountryName == "PRK") { printableCountryName = "North Korea"; }
        if (detectedCountryName == "KOR") { printableCountryName = "South Korea"; }
        if (detectedCountryName == "KWT") { printableCountryName = "Kuwait"; }
        if (detectedCountryName == "KAZ") { printableCountryName = "Kazakhstan"; }
        if (detectedCountryName == "LAO") { printableCountryName = "Laos"; }
        if (detectedCountryName == "LBN") { printableCountryName = "Lebanon"; }
        if (detectedCountryName == "LCA") { printableCountryName = "Saint Lucia"; }
        if (detectedCountryName == "LIE") { printableCountryName = "Liechtenstein"; }
        if (detectedCountryName == "LKA") { printableCountryName = "Sri Lanka"; }
        if (detectedCountryName == "LBR") { printableCountryName = "Liberia"; }
        if (detectedCountryName == "LSO") { printableCountryName = "Lesotho"; }
        if (detectedCountryName == "LTU") { printableCountryName = "Lithuania"; }
        if (detectedCountryName == "LUX") { printableCountryName = "Luxembourg"; }
        if (detectedCountryName == "LVA") { printableCountryName = "Latvia"; }
        if (detectedCountryName == "LBY") { printableCountryName = "Libya"; }
        if (detectedCountryName == "MAR") { printableCountryName = "Morocco"; }
        if (detectedCountryName == "MCO") { printableCountryName = "Monaco"; }
        if (detectedCountryName == "MDA") { printableCountryName = "Moldova"; }
        if (detectedCountryName == "MNE") { printableCountryName = "Montenegro"; }
        if (detectedCountryName == "MDG") { printableCountryName = "Madagascar"; }
        if (detectedCountryName == "MHL") { printableCountryName = "Marshall Islands"; }
        if (detectedCountryName == "MKD") { printableCountryName = "North Macedonia"; }
        if (detectedCountryName == "MLI") { printableCountryName = "Mali"; }
        if (detectedCountryName == "MMR") { printableCountryName = "Myanmar"; }
        if (detectedCountryName == "MNG") { printableCountryName = "Mongolia"; }
        if (detectedCountryName == "MAC") { printableCountryName = "Macao"; }
        if (detectedCountryName == "MRT") { printableCountryName = "Mauritania"; }
        if (detectedCountryName == "MLT") { printableCountryName = "Malta"; }
        if (detectedCountryName == "MUS") { printableCountryName = "Mauritius"; }
        if (detectedCountryName == "MDV") { printableCountryName = "Maldives"; }
        if (detectedCountryName == "MWI") { printableCountryName = "Malawi"; }
        if (detectedCountryName == "MEX") { printableCountryName = "Mexico"; }
        if (detectedCountryName == "MYS") { printableCountryName = "Malaysia"; }
        if (detectedCountryName == "MOZ") { printableCountryName = "Mozambique"; }
        if (detectedCountryName == "NAM") { printableCountryName = "Namibia"; }
        if (detectedCountryName == "NER") { printableCountryName = "Niger"; }
        if (detectedCountryName == "NGA") { printableCountryName = "Nigeria"; }
        if (detectedCountryName == "NIC") { printableCountryName = "Nicaragua"; }
        if (detectedCountryName == "NLD") { printableCountryName = "Netherlands"; }
        if (detectedCountryName == "NOR") { printableCountryName = "Norway"; }
        if (detectedCountryName == "NPL") { printableCountryName = "Nepal"; }
        if (detectedCountryName == "NRU") { printableCountryName = "Nauru"; }
        if (detectedCountryName == "NZL") { printableCountryName = "New Zealand"; }
        if (detectedCountryName == "OMN") { printableCountryName = "Oman"; }
        if (detectedCountryName == "PAN") { printableCountryName = "Panama"; }
        if (detectedCountryName == "PER") { printableCountryName = "Peru"; }
        if (detectedCountryName == "PNG") { printableCountryName = "Papua New Guinea"; }
        if (detectedCountryName == "PHL") { printableCountryName = "Philippines"; }
        if (detectedCountryName == "PAK") { printableCountryName = "Pakistan"; }
        if (detectedCountryName == "POL") { printableCountryName = "Poland"; }
        if (detectedCountryName == "PSE") { printableCountryName = "Palestine"; }
        if (detectedCountryName == "PRT") { printableCountryName = "Portugal"; }
        if (detectedCountryName == "PLW") { printableCountryName = "Palau"; }
        if (detectedCountryName == "PRY") { printableCountryName = "Paraguay"; }
        if (detectedCountryName == "QAT") { printableCountryName = "Qatar"; }
        if (detectedCountryName == "KOS") { printableCountryName = "Kosovo"; }
        if (detectedCountryName == "ROU") { printableCountryName = "Romania"; }
        if (detectedCountryName == "SRB") { printableCountryName = "Serbia"; }
        if (detectedCountryName == "RUS") { printableCountryName = "Russia"; }
        if (detectedCountryName == "RWA") { printableCountryName = "Rwanda"; }
        if (detectedCountryName == "SAU") { printableCountryName = "Saudi Arabia"; }
        if (detectedCountryName == "SLB") { printableCountryName = "Solomon Islands"; }
        if (detectedCountryName == "SYC") { printableCountryName = "Seychelles"; }
        if (detectedCountryName == "SDN") { printableCountryName = "Sudan"; }
        if (detectedCountryName == "SWE") { printableCountryName = "Sweden"; }
        if (detectedCountryName == "SGP") { printableCountryName = "Singapore"; }
        if (detectedCountryName == "SVN") { printableCountryName = "Slovenia"; }
        if (detectedCountryName == "SVK") { printableCountryName = "Slovakia"; }
        if (detectedCountryName == "SLE") { printableCountryName = "Sierra Leone"; }
        if (detectedCountryName == "SMR") { printableCountryName = "San Marino"; }
        if (detectedCountryName == "SEN") { printableCountryName = "Senegal"; }
        if (detectedCountryName == "SOM") { printableCountryName = "Somalia"; }
        if (detectedCountryName == "SUR") { printableCountryName = "Suriname"; }
        if (detectedCountryName == "SSD") { printableCountryName = "South Sudan"; }
        if (detectedCountryName == "STP") { printableCountryName = "Sao Tome and Principe"; }
        if (detectedCountryName == "SLV") { printableCountryName = "El Salvador"; }
        if (detectedCountryName == "SYR") { printableCountryName = "Syria"; }
        if (detectedCountryName == "SWZ") { printableCountryName = "Eswatini"; }
        if (detectedCountryName == "TCD") { printableCountryName = "Chad"; }
        if (detectedCountryName == "TGO") { printableCountryName = "Togo"; }
        if (detectedCountryName == "THA") { printableCountryName = "Thailand"; }
        if (detectedCountryName == "TJK") { printableCountryName = "Tajikistan"; }
        if (detectedCountryName == "TLS") { printableCountryName = "Timor-Leste"; }
        if (detectedCountryName == "TKM") { printableCountryName = "Turkmenistan"; }
        if (detectedCountryName == "TUN") { printableCountryName = "Tunisia"; }
        if (detectedCountryName == "TON") { printableCountryName = "Tonga"; }
        if (detectedCountryName == "TUR") { printableCountryName = "Turkey"; }
        if (detectedCountryName == "TTO") { printableCountryName = "Trinidad and Tobago"; }
        if (detectedCountryName == "TUV") { printableCountryName = "Tuvalu"; }
        if (detectedCountryName == "TWN") { printableCountryName = "Taiwan"; }
        if (detectedCountryName == "TZA") { printableCountryName = "Tanzania"; }
        if (detectedCountryName == "UKR") { printableCountryName = "Ukraine"; }
        if (detectedCountryName == "UGA") { printableCountryName = "Uganda"; }
        if (detectedCountryName == "USA") { printableCountryName = "United States of America"; }
        if (detectedCountryName == "URY") { printableCountryName = "Uruguay"; }
        if (detectedCountryName == "UZB") { printableCountryName = "Uzbekistan"; }
        if (detectedCountryName == "VAT") { printableCountryName = "Vatican City State"; }
        if (detectedCountryName == "VCT") { printableCountryName = "St. Vincent & the Grenadines"; }
        if (detectedCountryName == "VEN") { printableCountryName = "Venezuela"; }
        if (detectedCountryName == "VNM") { printableCountryName = "Vietnam"; }
        if (detectedCountryName == "VUT") { printableCountryName = "Vanuatu"; }
        if (detectedCountryName == "WSM") { printableCountryName = "Samoa"; }
        if (detectedCountryName == "YEM") { printableCountryName = "Yemen"; }
        if (detectedCountryName == "ZAF") { printableCountryName = "South Africa"; }
        if (detectedCountryName == "ZMB") { printableCountryName = "Zambia"; }
        if (detectedCountryName == "ZWE") { printableCountryName = "Zimbabwe"; }
        if (detectedCountryName == "GBR") { printableCountryName = "United Kingdom"; }
    }
}
