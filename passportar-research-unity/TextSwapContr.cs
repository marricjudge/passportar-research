using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSwapContr : MonoBehaviour
{
    public Text swaptext;
    public Text DebugText;
    private ChangeSceneOnCountryTouch ChangeSceneOnCountryTouchContr;
    private EarthMeshController EarthMeshContr;
    private PassportIdentDict PassportIdentDictContr;
    public string detectedCountryName;
    public string printableCountryName = "EMPTY";
    public List<int> detectedDataList;
    private string printDebugString = "";
    private string seperator = ", ";
    private int catchedClickedIntDebug;
    private int currentNationalityInt = -1;
    private string printCountryScan;
    private bool updated = false;
    private string receivedNat;

    public void Awake()
    {
        ChangeSceneOnCountryTouchContr = GameObject.FindObjectOfType<ChangeSceneOnCountryTouch>();
        EarthMeshContr = GameObject.FindObjectOfType<EarthMeshController>();
        PassportIdentDictContr = GameObject.FindObjectOfType<PassportIdentDict>();
    }

    public void Start()
    {
        swaptext.text = currentNationalityInt.ToString() + printCountryScan;
    }

    public void catchNationalityIntFromViz(int nationalityInt) //Gets the recognised passport int from AugmendImageVisualizer.cs
    {
        currentNationalityInt = nationalityInt;
    }

    void Update()
    {
        detectedCountryName = ChangeSceneOnCountryTouchContr.catchClickedCountry();
        setScanCountryIdent(currentNationalityInt);
        detectedCountryToPrintableName();
        receivedNat = PlayerPrefs.GetString("savedNationality");

        if (detectedCountryName == "EMPTY" || detectedCountryName == "EARTH_MESH" || detectedCountryName == "EARTH_MESH_map")
        {
            swaptext.text = receivedNat;
        } else
        {
           swaptext.text = printableCountryName;
        }
    }

    private void setScanCountryIdent(int currentNationalityInt)
    {
        if (currentNationalityInt == 0) { printCountryScan = "Germany"; }
        if (currentNationalityInt == 1) { printCountryScan = "Andorra"; }
        if (currentNationalityInt == 2) { printCountryScan = "United Arab Emirates"; }
        if (currentNationalityInt == 3) { printCountryScan = "Afghanistan"; }
        if (currentNationalityInt == 4) { printCountryScan = "Antigua & Barbuda"; }
        if (currentNationalityInt == 5) { printCountryScan = "Albania"; }
        if (currentNationalityInt == 6) { printCountryScan = "Armenia"; }
        if (currentNationalityInt == 7) { printCountryScan = "Angola"; }
        if (currentNationalityInt == 8) { printCountryScan = "Argentina"; }
        if (currentNationalityInt == 9) { printCountryScan = "Austria"; }
        if (currentNationalityInt == 10) { printCountryScan = "Australia"; }
        if (currentNationalityInt == 11) { printCountryScan = "Azerbaijan"; }
        if (currentNationalityInt == 12) { printCountryScan = "Bosnia & Herzegovina"; }
        if (currentNationalityInt == 13) { printCountryScan = "Barbados"; }
        if (currentNationalityInt == 14) { printCountryScan = "Bangladesh"; }
        if (currentNationalityInt == 15) { printCountryScan = "Belgium"; }
        if (currentNationalityInt == 16) { printCountryScan = "Burkina Faso"; }
        if (currentNationalityInt == 17) { printCountryScan = "Bulgaria"; }
        if (currentNationalityInt == 18) { printCountryScan = "Bahrain"; }
        if (currentNationalityInt == 19) { printCountryScan = "Burundi"; }
        if (currentNationalityInt == 20) { printCountryScan = "Benin"; }
        if (currentNationalityInt == 21) { printCountryScan = "Brunei"; }
        if (currentNationalityInt == 22) { printCountryScan = "Bolivia"; }
        if (currentNationalityInt == 23) { printCountryScan = "Brazil"; }
        if (currentNationalityInt == 24) { printCountryScan = "Bahamas"; }
        if (currentNationalityInt == 25) { printCountryScan = "Bhutan"; }
        if (currentNationalityInt == 26) { printCountryScan = "Botswana"; }
        if (currentNationalityInt == 27) { printCountryScan = "Belarus"; }
        if (currentNationalityInt == 28) { printCountryScan = "Belize"; }
        if (currentNationalityInt == 29) { printCountryScan = "Canada"; }
        if (currentNationalityInt == 30) { printCountryScan = "DR Congo"; }
        if (currentNationalityInt == 31) { printCountryScan = "Central African Republic"; }
        if (currentNationalityInt == 32) { printCountryScan = "Congo"; }
        if (currentNationalityInt == 33) { printCountryScan = "Switzerland"; }
        if (currentNationalityInt == 34) { printCountryScan = "Coted'Ivoire"; }
        if (currentNationalityInt == 35) { printCountryScan = "Chile"; }
        if (currentNationalityInt == 36) { printCountryScan = "Cameroon"; }
        if (currentNationalityInt == 37) { printCountryScan = "China"; }
        if (currentNationalityInt == 38) { printCountryScan = "Colombia"; }
        if (currentNationalityInt == 39) { printCountryScan = "Costa Rica"; }
        if (currentNationalityInt == 40) { printCountryScan = "Cuba"; }
        if (currentNationalityInt == 41) { printCountryScan = "Cape Verde"; }
        if (currentNationalityInt == 42) { printCountryScan = "Cyprus"; }
        if (currentNationalityInt == 43) { printCountryScan = "Czech Republic"; }
        if (currentNationalityInt == 44) { printCountryScan = "Germany"; }
        if (currentNationalityInt == 45) { printCountryScan = "Djibouti"; }
        if (currentNationalityInt == 46) { printCountryScan = "Denmark"; }
        if (currentNationalityInt == 47) { printCountryScan = "Dominica"; }
        if (currentNationalityInt == 48) { printCountryScan = "Dominican Republic"; }
        if (currentNationalityInt == 49) { printCountryScan = "Algeria"; }
        if (currentNationalityInt == 50) { printCountryScan = "Ecuador"; }
        if (currentNationalityInt == 51) { printCountryScan = "Estonia"; }
        if (currentNationalityInt == 52) { printCountryScan = "Egypt"; }
        if (currentNationalityInt == 53) { printCountryScan = "Eritrea"; }
        if (currentNationalityInt == 54) { printCountryScan = "Spain"; }
        if (currentNationalityInt == 55) { printCountryScan = "Ethiopia"; }
        if (currentNationalityInt == 56) { printCountryScan = "Finland"; }
        if (currentNationalityInt == 57) { printCountryScan = "Fiji"; }
        if (currentNationalityInt == 58) { printCountryScan = "Micronesia"; }
        if (currentNationalityInt == 59) { printCountryScan = "France"; }
        if (currentNationalityInt == 60) { printCountryScan = "Gabon"; }
        if (currentNationalityInt == 61 || currentNationalityInt == 200) { printCountryScan = "United Kingdom"; }
        if (currentNationalityInt == 62) { printCountryScan = "Grenada"; }
        if (currentNationalityInt == 63) { printCountryScan = "Georgia"; }
        if (currentNationalityInt == 64) { printCountryScan = "Ghana"; }
        if (currentNationalityInt == 65) { printCountryScan = "Gambia"; }
        if (currentNationalityInt == 66) { printCountryScan = "Guinea"; }
        if (currentNationalityInt == 67) { printCountryScan = "Equatorial Guinea"; }
        if (currentNationalityInt == 68) { printCountryScan = "Greece"; }
        if (currentNationalityInt == 69) { printCountryScan = "Guatemala"; }
        if (currentNationalityInt == 70) { printCountryScan = "Guinea-Bissau"; }
        if (currentNationalityInt == 71) { printCountryScan = "Guyana"; }
        if (currentNationalityInt == 72) { printCountryScan = "Hong Kong"; }
        if (currentNationalityInt == 73) { printCountryScan = "Honduras"; }
        if (currentNationalityInt == 74) { printCountryScan = "Croatia"; }
        if (currentNationalityInt == 75) { printCountryScan = "Haiti"; }
        if (currentNationalityInt == 76) { printCountryScan = "Hungary"; }
        if (currentNationalityInt == 77) { printCountryScan = "Indonesia"; }
        if (currentNationalityInt == 78) { printCountryScan = "Ireland"; }
        if (currentNationalityInt == 79) { printCountryScan = "Israel"; }
        if (currentNationalityInt == 80) { printCountryScan = "India"; }
        if (currentNationalityInt == 81) { printCountryScan = "Iraq"; }
        if (currentNationalityInt == 82) { printCountryScan = "Iran"; }
        if (currentNationalityInt == 83) { printCountryScan = "Iceland"; }
        if (currentNationalityInt == 84) { printCountryScan = "Italy"; }
        if (currentNationalityInt == 85) { printCountryScan = "Jamaica"; }
        if (currentNationalityInt == 86) { printCountryScan = "Jordan"; }
        if (currentNationalityInt == 87) { printCountryScan = "Japan"; }
        if (currentNationalityInt == 88) { printCountryScan = "Kenya"; }
        if (currentNationalityInt == 89) { printCountryScan = "Kyrgyzstan"; }
        if (currentNationalityInt == 90) { printCountryScan = "Cambodia"; }
        if (currentNationalityInt == 91) { printCountryScan = "Kiribati"; }
        if (currentNationalityInt == 92) { printCountryScan = "Comoros"; }
        if (currentNationalityInt == 93) { printCountryScan = "St Kitts & Nevis"; }
        if (currentNationalityInt == 94) { printCountryScan = "North Korea"; }
        if (currentNationalityInt == 95) { printCountryScan = "South Korea"; }
        if (currentNationalityInt == 96) { printCountryScan = "Kuwait"; }
        if (currentNationalityInt == 97) { printCountryScan = "Kazakhstan"; }
        if (currentNationalityInt == 98) { printCountryScan = "Laos"; }
        if (currentNationalityInt == 99) { printCountryScan = "Lebanon"; }
        if (currentNationalityInt == 100) { printCountryScan = "Saint Lucia"; }
        if (currentNationalityInt == 101) { printCountryScan = "Liechtenstein"; }
        if (currentNationalityInt == 102) { printCountryScan = "Sri Lanka"; }
        if (currentNationalityInt == 103) { printCountryScan = "Liberia"; }
        if (currentNationalityInt == 104) { printCountryScan = "Lesotho"; }
        if (currentNationalityInt == 105) { printCountryScan = "Lithuania"; }
        if (currentNationalityInt == 106) { printCountryScan = "Luxembourg"; }
        if (currentNationalityInt == 107) { printCountryScan = "Latvia"; }
        if (currentNationalityInt == 108) { printCountryScan = "Libya"; }
        if (currentNationalityInt == 109) { printCountryScan = "Morocco"; }
        if (currentNationalityInt == 110) { printCountryScan = "Monaco"; }
        if (currentNationalityInt == 111) { printCountryScan = "Moldova"; }
        if (currentNationalityInt == 112) { printCountryScan = "Montenegro"; }
        if (currentNationalityInt == 113) { printCountryScan = "Madagascar"; }
        if (currentNationalityInt == 114) { printCountryScan = "Marshall Islands"; }
        if (currentNationalityInt == 115) { printCountryScan = "North Macedonia"; }
        if (currentNationalityInt == 116) { printCountryScan = "Mali"; }
        if (currentNationalityInt == 117) { printCountryScan = "Myanmar"; }
        if (currentNationalityInt == 118) { printCountryScan = "Mongolia"; }
        if (currentNationalityInt == 119) { printCountryScan = "Macao"; }
        if (currentNationalityInt == 120) { printCountryScan = "Mauritania"; }
        if (currentNationalityInt == 121) { printCountryScan = "Malta"; }
        if (currentNationalityInt == 122) { printCountryScan = "Mauritius"; }
        if (currentNationalityInt == 123) { printCountryScan = "Maldives"; }
        if (currentNationalityInt == 124) { printCountryScan = "Malawi"; }
        if (currentNationalityInt == 125) { printCountryScan = "Mexico"; }
        if (currentNationalityInt == 126) { printCountryScan = "Malaysia"; }
        if (currentNationalityInt == 127) { printCountryScan = "Mozambique"; }
        if (currentNationalityInt == 128) { printCountryScan = "Namibia"; }
        if (currentNationalityInt == 129) { printCountryScan = "Niger"; }
        if (currentNationalityInt == 130) { printCountryScan = "Nigeria"; }
        if (currentNationalityInt == 131) { printCountryScan = "Nicaragua"; }
        if (currentNationalityInt == 132) { printCountryScan = "Netherlands"; }
        if (currentNationalityInt == 133) { printCountryScan = "Norway"; }
        if (currentNationalityInt == 134) { printCountryScan = "Nepal"; }
        if (currentNationalityInt == 135) { printCountryScan = "Nauru"; }
        if (currentNationalityInt == 136) { printCountryScan = "New Zealand"; }
        if (currentNationalityInt == 137) { printCountryScan = "Oman"; }
        if (currentNationalityInt == 138) { printCountryScan = "Panama"; }
        if (currentNationalityInt == 139) { printCountryScan = "Peru"; }
        if (currentNationalityInt == 140) { printCountryScan = "Papua New Guinea"; }
        if (currentNationalityInt == 141) { printCountryScan = "Philippines"; }
        if (currentNationalityInt == 142) { printCountryScan = "Pakistan"; }
        if (currentNationalityInt == 143) { printCountryScan = "Poland"; }
        if (currentNationalityInt == 144) { printCountryScan = "Palestine"; }
        if (currentNationalityInt == 145) { printCountryScan = "Portugal"; }
        if (currentNationalityInt == 146) { printCountryScan = "Palau"; }
        if (currentNationalityInt == 147) { printCountryScan = "Paraguay"; }
        if (currentNationalityInt == 148) { printCountryScan = "Qatar"; }
        if (currentNationalityInt == 149) { printCountryScan = "Kosovo"; }
        if (currentNationalityInt == 150) { printCountryScan = "Romania"; }
        if (currentNationalityInt == 151) { printCountryScan = "Serbia"; }
        if (currentNationalityInt == 152) { printCountryScan = "Russia"; }
        if (currentNationalityInt == 153) { printCountryScan = "Rwanda"; }
        if (currentNationalityInt == 154) { printCountryScan = "Saudi Arabia"; }
        if (currentNationalityInt == 155) { printCountryScan = "Solomon Islands"; }
        if (currentNationalityInt == 156) { printCountryScan = "Seychelles"; }
        if (currentNationalityInt == 157) { printCountryScan = "Sudan"; }
        if (currentNationalityInt == 158) { printCountryScan = "Sweden"; }
        if (currentNationalityInt == 159) { printCountryScan = "Singapore"; }
        if (currentNationalityInt == 160) { printCountryScan = "Slovenia"; }
        if (currentNationalityInt == 161) { printCountryScan = "Slovakia"; }
        if (currentNationalityInt == 162) { printCountryScan = "Sierra Leone"; }
        if (currentNationalityInt == 163) { printCountryScan = "San Marino"; }
        if (currentNationalityInt == 164) { printCountryScan = "Senegal"; }
        if (currentNationalityInt == 165) { printCountryScan = "Somalia"; }
        if (currentNationalityInt == 166) { printCountryScan = "Suriname"; }
        if (currentNationalityInt == 167) { printCountryScan = "South Sudan"; }
        if (currentNationalityInt == 168) { printCountryScan = "Sao Tome and Principe"; }
        if (currentNationalityInt == 169) { printCountryScan = "El Salvador"; }
        if (currentNationalityInt == 170) { printCountryScan = "Syria"; }
        if (currentNationalityInt == 171) { printCountryScan = "Eswatini"; }
        if (currentNationalityInt == 172) { printCountryScan = "Chad"; }
        if (currentNationalityInt == 173) { printCountryScan = "Togo"; }
        if (currentNationalityInt == 174) { printCountryScan = "Thailand"; }
        if (currentNationalityInt == 175) { printCountryScan = "Tajikistan"; }
        if (currentNationalityInt == 176) { printCountryScan = "Timor-Leste"; }
        if (currentNationalityInt == 177) { printCountryScan = "Turkmenistan"; }
        if (currentNationalityInt == 178) { printCountryScan = "Tunisia"; }
        if (currentNationalityInt == 179) { printCountryScan = "Tonga"; }
        if (currentNationalityInt == 180) { printCountryScan = "Turkey"; }
        if (currentNationalityInt == 181) { printCountryScan = "Trinidad and Tobago"; }
        if (currentNationalityInt == 182) { printCountryScan = "Tuvalu"; }
        if (currentNationalityInt == 183) { printCountryScan = "Taiwan"; }
        if (currentNationalityInt == 184) { printCountryScan = "Tanzania"; }
        if (currentNationalityInt == 185) { printCountryScan = "Ukraine"; }
        if (currentNationalityInt == 186) { printCountryScan = "Uganda"; }
        if (currentNationalityInt == 187) { printCountryScan = "United States of America"; }
        if (currentNationalityInt == 188) { printCountryScan = "Uruguay"; }
        if (currentNationalityInt == 189) { printCountryScan = "Uzbekistan"; }
        if (currentNationalityInt == 190) { printCountryScan = "Vatican City State"; }
        if (currentNationalityInt == 191) { printCountryScan = "St. Vincent & the Grenadines"; }
        if (currentNationalityInt == 192) { printCountryScan = "Venezuela"; }
        if (currentNationalityInt == 193) { printCountryScan = "Vietnam"; }
        if (currentNationalityInt == 194) { printCountryScan = "Vanuatu"; }
        if (currentNationalityInt == 195) { printCountryScan = "Samoa"; }
        if (currentNationalityInt == 196) { printCountryScan = "Yemen"; }
        if (currentNationalityInt == 197) { printCountryScan = "South Africa"; }
        if (currentNationalityInt == 198) { printCountryScan = "Zambia"; }
        if (currentNationalityInt == 199) { printCountryScan = "Zimbabwe"; }
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
