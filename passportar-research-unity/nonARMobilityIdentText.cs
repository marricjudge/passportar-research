using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nonARMobilityIdentText : MonoBehaviour
{
    public Text mobilityDigitText;
    public Text rankDigitText;
    private LoadPassportData LoadPassportDataContr;
    private ChangeSceneOnCountryTouch ChangeSceneOnCountryTouchContr;
    private List<int> PassportPowerDataList = new List<int>();
    private List<int> PassportRankDataList = new List<int>();
    public string detectedCountryName;
    private int countryIdentifier;
    private int printablePassportPowerNumber;
    private int currentNationalityInt;
    private int scanCountryIdent;
    private string preQselected;

    public void Awake()
    {
        LoadPassportDataContr = GameObject.FindObjectOfType<LoadPassportData>();
        ChangeSceneOnCountryTouchContr = GameObject.FindObjectOfType<ChangeSceneOnCountryTouch>();
    }

    private void Start()
    {
        preQselected = PlayerPrefs.GetString("PreQ5Ans");
        detectedCountryName = ChangeSceneOnCountryTouchContr.catchClickedCountry();
        PassportPowerDataList = LoadPassportDataContr.sendPassportPowerList();
        PassportRankDataList = LoadPassportDataContr.sendPassportRankList();
        setCountryIdentifier();
        setScanCountryIdent();

        mobilityDigitText.text = PassportPowerDataList[scanCountryIdent].ToString();
        rankDigitText.text = "#" + PassportRankDataList[scanCountryIdent].ToString();
    }

    void Update()
    {
        preQselected = PlayerPrefs.GetString("PreQ5Ans");
        detectedCountryName = ChangeSceneOnCountryTouchContr.catchClickedCountry();
        PassportPowerDataList = LoadPassportDataContr.sendPassportPowerList();
        PassportRankDataList = LoadPassportDataContr.sendPassportRankList();
        setCountryIdentifier();
        setScanCountryIdent();

        if (detectedCountryName == "EMPTY" || detectedCountryName == "EARTH_MESH" || detectedCountryName == "EARTH_MESH_map") 
        {

        }
        else
        {
            mobilityDigitText.text = PassportPowerDataList[countryIdentifier].ToString();
            rankDigitText.text = "#" + PassportRankDataList[countryIdentifier].ToString();
        }
    }

    private void setScanCountryIdent()
    {
        if (preQselected == "Afghanistan") { scanCountryIdent = 1; }
        if (preQselected == "Albania") { scanCountryIdent = 2; }
        if (preQselected == "Algeria") { scanCountryIdent = 3; }
        if (preQselected == "Andorra") { scanCountryIdent = 4; }
        if (preQselected == "Angola") { scanCountryIdent = 5; }
        if (preQselected == "Antigua and Barbuda") { scanCountryIdent = 6; }
        if (preQselected == "Argentina") { scanCountryIdent = 7; }
        if (preQselected == "Armenia") { scanCountryIdent = 8; }
        if (preQselected == "Australia") { scanCountryIdent = 9; }
        if (preQselected == "Austria") { scanCountryIdent = 10; }
        if (preQselected == "Azerbaijan") { scanCountryIdent = 11; }
        if (preQselected == "Bahamas") { scanCountryIdent = 12; }
        if (preQselected == "Bahrain") { scanCountryIdent = 13; }
        if (preQselected == "Bangladesh") { scanCountryIdent = 14; }
        if (preQselected == "Barbados") { scanCountryIdent = 15; }
        if (preQselected == "Belarus") { scanCountryIdent = 16; }
        if (preQselected == "Belgium") { scanCountryIdent = 17; }
        if (preQselected == "Belize") { scanCountryIdent = 18; }
        if (preQselected == "Benin") { scanCountryIdent = 19; }
        if (preQselected == "Bhutan") { scanCountryIdent = 20; }
        if (preQselected == "Bolivia") { scanCountryIdent = 21; }
        if (preQselected == "Bosnia and Herzegovina") { scanCountryIdent = 22; }
        if (preQselected == "Botswana") { scanCountryIdent = 23; }
        if (preQselected == "Brazil") { scanCountryIdent = 24; }
        if (preQselected == "Brunei") { scanCountryIdent = 25; }
        if (preQselected == "Bulgaria") { scanCountryIdent = 26; }
        if (preQselected == "Burkina Faso") { scanCountryIdent = 27; }
        if (preQselected == "Burundi") { scanCountryIdent = 28; }
        if (preQselected == "Cambodia") { scanCountryIdent = 29; }
        if (preQselected == "Cameroon") { scanCountryIdent = 30; }
        if (preQselected == "Canada") { scanCountryIdent = 31; }
        if (preQselected == "Cape Verde") { scanCountryIdent = 32; }
        if (preQselected == "Central African Republic") { scanCountryIdent = 33; }
        if (preQselected == "Chad") { scanCountryIdent = 34; }
        if (preQselected == "Chile") { scanCountryIdent = 35; }
        if (preQselected == "China") { scanCountryIdent = 36; }
        if (preQselected == "Colombia") { scanCountryIdent = 37; }
        if (preQselected == "Comoros") { scanCountryIdent = 38; }
        if (preQselected == "Congo") { scanCountryIdent = 39; }
        if (preQselected == "Congo DR") { scanCountryIdent = 40; }
        if (preQselected == "Costa Rica") { scanCountryIdent = 41; }
        if (preQselected == "Cote d'Ivoire") { scanCountryIdent = 42; }
        if (preQselected == "Croatia") { scanCountryIdent = 43; }
        if (preQselected == "Cuba") { scanCountryIdent = 44; }
        if (preQselected == "Cyprus") { scanCountryIdent = 45; }
        if (preQselected == "Czech Republic") { scanCountryIdent = 46; }
        if (preQselected == "Denmark") { scanCountryIdent = 47; }
        if (preQselected == "Djibouti") { scanCountryIdent = 48; }
        if (preQselected == "Dominica") { scanCountryIdent = 49; }
        if (preQselected == "Dominican Republic") { scanCountryIdent = 50; }
        if (preQselected == "Ecuador") { scanCountryIdent = 51; }
        if (preQselected == "Egypt") { scanCountryIdent = 52; }
        if (preQselected == "El Salvador") { scanCountryIdent = 53; }
        if (preQselected == "Equatorial Guinea") { scanCountryIdent = 54; }
        if (preQselected == "Eritrea") { scanCountryIdent = 55; }
        if (preQselected == "Estonia") { scanCountryIdent = 56; }
        if (preQselected == "Swaziland") { scanCountryIdent = 57; }
        if (preQselected == "Ethiopia") { scanCountryIdent = 58; }
        if (preQselected == "Fiji") { scanCountryIdent = 59; }
        if (preQselected == "Finland") { scanCountryIdent = 60; }
        if (preQselected == "France") { scanCountryIdent = 61; }
        if (preQselected == "Gabon") { scanCountryIdent = 62; }
        if (preQselected == "Gambia") { scanCountryIdent = 63; }
        if (preQselected == "Georgia") { scanCountryIdent = 64; }
        if (preQselected == "Germany") { scanCountryIdent = 65; }
        if (preQselected == "Ghana") { scanCountryIdent = 66; }
        if (preQselected == "Greece") { scanCountryIdent = 67; }
        if (preQselected == "Grenada") { scanCountryIdent = 68; }
        if (preQselected == "Guatemala") { scanCountryIdent = 69; }
        if (preQselected == "Guinea") { scanCountryIdent = 70; }
        if (preQselected == "Guinea-Bissau") { scanCountryIdent = 71; }
        if (preQselected == "Guyana") { scanCountryIdent = 72; }
        if (preQselected == "Haiti") { scanCountryIdent = 73; }
        if (preQselected == "Honduras") { scanCountryIdent = 74; }
        if (preQselected == "Hong Kong") { scanCountryIdent = 75; }
        if (preQselected == "Hungary") { scanCountryIdent = 76; }
        if (preQselected == "Iceland") { scanCountryIdent = 77; }
        if (preQselected == "India") { scanCountryIdent = 78; }
        if (preQselected == "Indonesia") { scanCountryIdent = 79; }
        if (preQselected == "Iran") { scanCountryIdent = 80; }
        if (preQselected == "Iraq") { scanCountryIdent = 81; }
        if (preQselected == "Ireland") { scanCountryIdent = 82; }
        if (preQselected == "Israel") { scanCountryIdent = 83; }
        if (preQselected == "Italy") { scanCountryIdent = 84; }
        if (preQselected == "Jamaica") { scanCountryIdent = 85; }
        if (preQselected == "Japan") { scanCountryIdent = 86; }
        if (preQselected == "Jordan") { scanCountryIdent = 87; }
        if (preQselected == "Kazakhstan") { scanCountryIdent = 88; }
        if (preQselected == "Kenya") { scanCountryIdent = 89; }
        if (preQselected == "Kiribati") { scanCountryIdent = 90; }
        if (preQselected == "Kosovo") { scanCountryIdent = 91; }
        if (preQselected == "Kuwait") { scanCountryIdent = 92; }
        if (preQselected == "Kyrgyzstan") { scanCountryIdent = 93; }
        if (preQselected == "Laos") { scanCountryIdent = 94; }
        if (preQselected == "Latvia") { scanCountryIdent = 95; }
        if (preQselected == "Lebanon") { scanCountryIdent = 96; }
        if (preQselected == "Lesotho") { scanCountryIdent = 97; }
        if (preQselected == "Liberia") { scanCountryIdent = 98; }
        if (preQselected == "Libya") { scanCountryIdent = 99; }
        if (preQselected == "Liechtenstein") { scanCountryIdent = 100; }
        if (preQselected == "Lithuania") { scanCountryIdent = 101; }
        if (preQselected == "Luxembourg") { scanCountryIdent = 102; }
        if (preQselected == "Macao") { scanCountryIdent = 103; }
        if (preQselected == "Madagascar") { scanCountryIdent = 104; }
        if (preQselected == "Malawi") { scanCountryIdent = 105; }
        if (preQselected == "Malaysia") { scanCountryIdent = 106; }
        if (preQselected == "Maldives") { scanCountryIdent = 107; }
        if (preQselected == "Mali") { scanCountryIdent = 108; }
        if (preQselected == "Malta") { scanCountryIdent = 109; }
        if (preQselected == "Marshall Islands") { scanCountryIdent = 110; }
        if (preQselected == "Mauritania") { scanCountryIdent = 111; }
        if (preQselected == "Mauritius") { scanCountryIdent = 112; }
        if (preQselected == "Mexico") { scanCountryIdent = 113; }
        if (preQselected == "Micronesia") { scanCountryIdent = 114; }
        if (preQselected == "Moldova") { scanCountryIdent = 115; }
        if (preQselected == "Monaco") { scanCountryIdent = 116; }
        if (preQselected == "Mongolia") { scanCountryIdent = 117; }
        if (preQselected == "Montenegro") { scanCountryIdent = 118; }
        if (preQselected == "Morocco") { scanCountryIdent = 119; }
        if (preQselected == "Mozambique") { scanCountryIdent = 120; }
        if (preQselected == "Myanmar") { scanCountryIdent = 121; }
        if (preQselected == "Namibia") { scanCountryIdent = 122; }
        if (preQselected == "Nauru") { scanCountryIdent = 123; }
        if (preQselected == "Nepal") { scanCountryIdent = 124; }
        if (preQselected == "Netherlands") { scanCountryIdent = 125; }
        if (preQselected == "New Zealand") { scanCountryIdent = 126; }
        if (preQselected == "Nicaragua") { scanCountryIdent = 127; }
        if (preQselected == "Niger") { scanCountryIdent = 128; }
        if (preQselected == "Nigeria") { scanCountryIdent = 129; }
        if (preQselected == "North Korea") { scanCountryIdent = 130; }
        if (preQselected == "North Macedonia") { scanCountryIdent = 131; }
        if (preQselected == "Norway") { scanCountryIdent = 132; }
        if (preQselected == "Oman") { scanCountryIdent = 133; }
        if (preQselected == "Pakistan") { scanCountryIdent = 134; }
        if (preQselected == "Palau") { scanCountryIdent = 135; }
        if (preQselected == "Palestinian Territory") { scanCountryIdent = 136; }
        if (preQselected == "Panama") { scanCountryIdent = 137; }
        if (preQselected == "Papua New Guinea") { scanCountryIdent = 138; }
        if (preQselected == "Paraguay") { scanCountryIdent = 139; }
        if (preQselected == "Peru") { scanCountryIdent = 140; }
        if (preQselected == "Philippines") { scanCountryIdent = 141; }
        if (preQselected == "Poland") { scanCountryIdent = 142; }
        if (preQselected == "Portugal") { scanCountryIdent = 143; }
        if (preQselected == "Qatar") { scanCountryIdent = 144; }
        if (preQselected == "Romania") { scanCountryIdent = 145; }
        if (preQselected == "Russia") { scanCountryIdent = 146; }
        if (preQselected == "Rwanda") { scanCountryIdent = 147; }
        if (preQselected == "Saint Kitts and Nevis") { scanCountryIdent = 148; }
        if (preQselected == "Saint Lucia") { scanCountryIdent = 149; }
        if (preQselected == "Samoa") { scanCountryIdent = 150; }
        if (preQselected == "SanMarino") { scanCountryIdent = 151; }
        if (preQselected == "Sao Tome and Principe") { scanCountryIdent = 152; }
        if (preQselected == "Saudi Arabia") { scanCountryIdent = 153; }
        if (preQselected == "Senegal") { scanCountryIdent = 154; }
        if (preQselected == "Serbia") { scanCountryIdent = 155; }
        if (preQselected == "Seychelles") { scanCountryIdent = 156; }
        if (preQselected == "Sierra Leone") { scanCountryIdent = 157; }
        if (preQselected == "Singapore") { scanCountryIdent = 158; }
        if (preQselected == "Slovakia") { scanCountryIdent = 159; }
        if (preQselected == "Slovenia") { scanCountryIdent = 160; }
        if (preQselected == "Solomon Islands") { scanCountryIdent = 161; }
        if (preQselected == "Somalia") { scanCountryIdent = 162; }
        if (preQselected == "South Africa") { scanCountryIdent = 163; }
        if (preQselected == "South Korea") { scanCountryIdent = 164; }
        if (preQselected == "South Sudan") { scanCountryIdent = 165; }
        if (preQselected == "Spain") { scanCountryIdent = 166; }
        if (preQselected == "Sri Lanka") { scanCountryIdent = 167; }
        if (preQselected == "Saint Vincent and the Grenadines") { scanCountryIdent = 168; }
        if (preQselected == "Sudan") { scanCountryIdent = 169; }
        if (preQselected == "Suriname") { scanCountryIdent = 170; }
        if (preQselected == "Sweden") { scanCountryIdent = 171; }
        if (preQselected == "Switzerland") { scanCountryIdent = 172; }
        if (preQselected == "Syria") { scanCountryIdent = 173; }
        if (preQselected == "Taiwan") { scanCountryIdent = 174; }
        if (preQselected == "Tajikistan") { scanCountryIdent = 175; }
        if (preQselected == "Tanzania") { scanCountryIdent = 176; }
        if (preQselected == "Thailand") { scanCountryIdent = 177; }
        if (preQselected == "Timor-Leste") { scanCountryIdent = 178; }
        if (preQselected == "Togo") { scanCountryIdent = 179; }
        if (preQselected == "Tonga") { scanCountryIdent = 180; }
        if (preQselected == "Trinidad and Tobago") { scanCountryIdent = 181; }
        if (preQselected == "Tunisia") { scanCountryIdent = 182; }
        if (preQselected == "Turkey") { scanCountryIdent = 183; }
        if (preQselected == "Turkmenistan") { scanCountryIdent = 184; }
        if (preQselected == "Tuvalu") { scanCountryIdent = 185; }
        if (preQselected == "Uganda") { scanCountryIdent = 186; }
        if (preQselected == "Ukraine") { scanCountryIdent = 187; }
        if (preQselected == "United Arab Emirates") { scanCountryIdent = 188; }
        if (preQselected == "United Kingdom") { scanCountryIdent = 189; }
        if (preQselected == "United States of America") { scanCountryIdent = 190; }
        if (preQselected == "Uruguay") { scanCountryIdent = 191; }
        if (preQselected == "Uzbekistan") { scanCountryIdent = 192; }
        if (preQselected == "Vanuatu") { scanCountryIdent = 193; }
        if (preQselected == "Vatican") { scanCountryIdent = 194; }
        if (preQselected == "Venezuela") { scanCountryIdent = 195; }
        if (preQselected == "Vietnam") { scanCountryIdent = 196; }
        if (preQselected == "Yemen") { scanCountryIdent = 197; }
        if (preQselected == "Zambia") { scanCountryIdent = 198; }
        if (preQselected == "Zimbabwe") { scanCountryIdent = 199; }
    }

    private void setCountryIdentifier()
    {
        if (detectedCountryName == "AFG") { countryIdentifier = 1; }
        if (detectedCountryName == "ALB") { countryIdentifier = 2; }
        if (detectedCountryName == "DZA") { countryIdentifier = 3; }
        if (detectedCountryName == "AND") { countryIdentifier = 4; }
        if (detectedCountryName == "AGO") { countryIdentifier = 5; }
        if (detectedCountryName == "ATG") { countryIdentifier = 6; }
        if (detectedCountryName == "ARG") { countryIdentifier = 7; }
        if (detectedCountryName == "ARM") { countryIdentifier = 8; }
        if (detectedCountryName == "AUS") { countryIdentifier = 9; }
        if (detectedCountryName == "AUT") { countryIdentifier = 10; }
        if (detectedCountryName == "AZE") { countryIdentifier = 11; }
        if (detectedCountryName == "BHS") { countryIdentifier = 12; }
        if (detectedCountryName == "BHR") { countryIdentifier = 13; }
        if (detectedCountryName == "BGD") { countryIdentifier = 14; }
        if (detectedCountryName == "BRB") { countryIdentifier = 15; }
        if (detectedCountryName == "BLR") { countryIdentifier = 16; }
        if (detectedCountryName == "BEL") { countryIdentifier = 17; }
        if (detectedCountryName == "BLZ") { countryIdentifier = 18; }
        if (detectedCountryName == "BEN") { countryIdentifier = 19; }
        if (detectedCountryName == "BTN") { countryIdentifier = 20; }
        if (detectedCountryName == "BOL") { countryIdentifier = 21; }
        if (detectedCountryName == "BIH") { countryIdentifier = 22; }
        if (detectedCountryName == "BWA") { countryIdentifier = 23; }
        if (detectedCountryName == "BRA") { countryIdentifier = 24; }
        if (detectedCountryName == "BRN") { countryIdentifier = 25; }
        if (detectedCountryName == "BGR") { countryIdentifier = 26; }
        if (detectedCountryName == "BFA") { countryIdentifier = 27; }
        if (detectedCountryName == "BDI") { countryIdentifier = 28; }
        if (detectedCountryName == "KHM") { countryIdentifier = 29; }
        if (detectedCountryName == "CMR") { countryIdentifier = 30; }
        if (detectedCountryName == "CAN") { countryIdentifier = 31; }
        if (detectedCountryName == "CPV") { countryIdentifier = 32; }
        if (detectedCountryName == "CAF") { countryIdentifier = 33; }
        if (detectedCountryName == "TCD") { countryIdentifier = 34; }
        if (detectedCountryName == "CHL") { countryIdentifier = 35; }
        if (detectedCountryName == "CHN") { countryIdentifier = 36; }
        if (detectedCountryName == "COL") { countryIdentifier = 37; }
        if (detectedCountryName == "COM") { countryIdentifier = 38; }
        if (detectedCountryName == "COG") { countryIdentifier = 39; }
        if (detectedCountryName == "COD") { countryIdentifier = 40; }
        if (detectedCountryName == "CRI") { countryIdentifier = 41; }
        if (detectedCountryName == "CIV") { countryIdentifier = 42; }
        if (detectedCountryName == "HRV") { countryIdentifier = 43; }
        if (detectedCountryName == "CUB") { countryIdentifier = 44; }
        if (detectedCountryName == "CYP") { countryIdentifier = 45; }
        if (detectedCountryName == "CZE") { countryIdentifier = 46; }
        if (detectedCountryName == "DNK") { countryIdentifier = 47; }
        if (detectedCountryName == "DJI") { countryIdentifier = 48; }
        if (detectedCountryName == "DMA") { countryIdentifier = 49; }
        if (detectedCountryName == "DOM") { countryIdentifier = 50; }
        if (detectedCountryName == "ECU") { countryIdentifier = 51; }
        if (detectedCountryName == "EGY") { countryIdentifier = 52; }
        if (detectedCountryName == "SLV") { countryIdentifier = 53; }
        if (detectedCountryName == "GNQ") { countryIdentifier = 54; }
        if (detectedCountryName == "ERI") { countryIdentifier = 55; }
        if (detectedCountryName == "EST") { countryIdentifier = 56; }
        if (detectedCountryName == "SWZ") { countryIdentifier = 57; }
        if (detectedCountryName == "ETH") { countryIdentifier = 58; }
        if (detectedCountryName == "FJI") { countryIdentifier = 59; }
        if (detectedCountryName == "FIN") { countryIdentifier = 60; }
        if (detectedCountryName == "FRA") { countryIdentifier = 61; }
        if (detectedCountryName == "GAB") { countryIdentifier = 62; }
        if (detectedCountryName == "GMB") { countryIdentifier = 63; }
        if (detectedCountryName == "GEO") { countryIdentifier = 64; }
        if (detectedCountryName == "DEU") { countryIdentifier = 65; }
        if (detectedCountryName == "GHA") { countryIdentifier = 66; }
        if (detectedCountryName == "GRC") { countryIdentifier = 67; }
        if (detectedCountryName == "GRD") { countryIdentifier = 68; }
        if (detectedCountryName == "GTM") { countryIdentifier = 69; }
        if (detectedCountryName == "GIN") { countryIdentifier = 70; }
        if (detectedCountryName == "GNB") { countryIdentifier = 71; }
        if (detectedCountryName == "GUY") { countryIdentifier = 72; }
        if (detectedCountryName == "HTI") { countryIdentifier = 73; }
        if (detectedCountryName == "HND") { countryIdentifier = 74; }
        if (detectedCountryName == "HKG") { countryIdentifier = 75; }
        if (detectedCountryName == "HUN") { countryIdentifier = 76; }
        if (detectedCountryName == "ISL") { countryIdentifier = 77; }
        if (detectedCountryName == "IND") { countryIdentifier = 78; }
        if (detectedCountryName == "IDN") { countryIdentifier = 79; }
        if (detectedCountryName == "IRN") { countryIdentifier = 80; }
        if (detectedCountryName == "IRQ") { countryIdentifier = 81; }
        if (detectedCountryName == "IRL") { countryIdentifier = 82; }
        if (detectedCountryName == "ISR") { countryIdentifier = 83; }
        if (detectedCountryName == "ITA") { countryIdentifier = 84; }
        if (detectedCountryName == "JAM") { countryIdentifier = 85; }
        if (detectedCountryName == "JPN") { countryIdentifier = 86; }
        if (detectedCountryName == "JOR") { countryIdentifier = 87; }
        if (detectedCountryName == "KAZ") { countryIdentifier = 88; }
        if (detectedCountryName == "KEN") { countryIdentifier = 89; }
        if (detectedCountryName == "KIR") { countryIdentifier = 90; }
        if (detectedCountryName == "KOS") { countryIdentifier = 91; }
        if (detectedCountryName == "KWT") { countryIdentifier = 92; }
        if (detectedCountryName == "KGZ") { countryIdentifier = 93; }
        if (detectedCountryName == "LAO") { countryIdentifier = 94; }
        if (detectedCountryName == "LVA") { countryIdentifier = 95; }
        if (detectedCountryName == "LBN") { countryIdentifier = 96; }
        if (detectedCountryName == "LSO") { countryIdentifier = 97; }
        if (detectedCountryName == "LBR") { countryIdentifier = 98; }
        if (detectedCountryName == "LBY") { countryIdentifier = 99; }
        if (detectedCountryName == "LIE") { countryIdentifier = 100; }
        if (detectedCountryName == "LTU") { countryIdentifier = 101; }
        if (detectedCountryName == "LUX") { countryIdentifier = 102; }
        if (detectedCountryName == "MAC") { countryIdentifier = 103; }
        if (detectedCountryName == "MDG") { countryIdentifier = 104; }
        if (detectedCountryName == "MWI") { countryIdentifier = 105; }
        if (detectedCountryName == "MYS") { countryIdentifier = 106; }
        if (detectedCountryName == "MDV") { countryIdentifier = 107; }
        if (detectedCountryName == "MLI") { countryIdentifier = 108; }
        if (detectedCountryName == "MLT") { countryIdentifier = 109; }
        if (detectedCountryName == "MHL") { countryIdentifier = 110; }
        if (detectedCountryName == "MRT") { countryIdentifier = 111; }
        if (detectedCountryName == "MUS") { countryIdentifier = 112; }
        if (detectedCountryName == "MEX") { countryIdentifier = 113; }
        if (detectedCountryName == "FSM") { countryIdentifier = 114; }
        if (detectedCountryName == "MDA") { countryIdentifier = 115; }
        if (detectedCountryName == "MCO") { countryIdentifier = 116; }
        if (detectedCountryName == "MNG") { countryIdentifier = 117; }
        if (detectedCountryName == "MNE") { countryIdentifier = 118; }
        if (detectedCountryName == "MAR") { countryIdentifier = 119; }
        if (detectedCountryName == "MOZ") { countryIdentifier = 120; }
        if (detectedCountryName == "MMR") { countryIdentifier = 121; }
        if (detectedCountryName == "NAM") { countryIdentifier = 122; }
        if (detectedCountryName == "NRU") { countryIdentifier = 123; }
        if (detectedCountryName == "NPL") { countryIdentifier = 124; }
        if (detectedCountryName == "NLD") { countryIdentifier = 125; }
        if (detectedCountryName == "NZL") { countryIdentifier = 126; }
        if (detectedCountryName == "NIC") { countryIdentifier = 127; }
        if (detectedCountryName == "NER") { countryIdentifier = 128; }
        if (detectedCountryName == "NGA") { countryIdentifier = 129; }
        if (detectedCountryName == "PRK") { countryIdentifier = 130; }
        if (detectedCountryName == "MKD") { countryIdentifier = 131; }
        if (detectedCountryName == "NOR") { countryIdentifier = 132; }
        if (detectedCountryName == "OMN") { countryIdentifier = 133; }
        if (detectedCountryName == "PAK") { countryIdentifier = 134; }
        if (detectedCountryName == "PLW") { countryIdentifier = 135; }
        if (detectedCountryName == "PSE") { countryIdentifier = 136; }
        if (detectedCountryName == "PAN") { countryIdentifier = 137; }
        if (detectedCountryName == "PNG") { countryIdentifier = 138; }
        if (detectedCountryName == "PRY") { countryIdentifier = 139; }
        if (detectedCountryName == "PER") { countryIdentifier = 140; }
        if (detectedCountryName == "PHL") { countryIdentifier = 141; }
        if (detectedCountryName == "POL") { countryIdentifier = 142; }
        if (detectedCountryName == "PRT") { countryIdentifier = 143; }
        if (detectedCountryName == "QAT") { countryIdentifier = 144; }
        if (detectedCountryName == "ROU") { countryIdentifier = 145; }
        if (detectedCountryName == "RUS") { countryIdentifier = 146; }
        if (detectedCountryName == "RWA") { countryIdentifier = 147; }
        if (detectedCountryName == "KNA") { countryIdentifier = 148; }
        if (detectedCountryName == "LCA") { countryIdentifier = 149; }
        if (detectedCountryName == "WSM") { countryIdentifier = 150; }
        if (detectedCountryName == "SMR") { countryIdentifier = 151; }
        if (detectedCountryName == "STP") { countryIdentifier = 152; }
        if (detectedCountryName == "SAU") { countryIdentifier = 153; }
        if (detectedCountryName == "SEN") { countryIdentifier = 154; }
        if (detectedCountryName == "SRB") { countryIdentifier = 155; }
        if (detectedCountryName == "SYC") { countryIdentifier = 156; }
        if (detectedCountryName == "SLE") { countryIdentifier = 157; }
        if (detectedCountryName == "SGP") { countryIdentifier = 158; }
        if (detectedCountryName == "SVK") { countryIdentifier = 159; }
        if (detectedCountryName == "SVN") { countryIdentifier = 160; }
        if (detectedCountryName == "SLB") { countryIdentifier = 161; }
        if (detectedCountryName == "SOM") { countryIdentifier = 162; }
        if (detectedCountryName == "ZAF") { countryIdentifier = 163; }
        if (detectedCountryName == "KOR") { countryIdentifier = 164; }
        if (detectedCountryName == "SSD") { countryIdentifier = 165; }
        if (detectedCountryName == "ESP") { countryIdentifier = 166; }
        if (detectedCountryName == "LKA") { countryIdentifier = 167; }
        if (detectedCountryName == "VCT") { countryIdentifier = 168; }
        if (detectedCountryName == "SDN") { countryIdentifier = 169; }
        if (detectedCountryName == "SUR") { countryIdentifier = 170; }
        if (detectedCountryName == "SWE") { countryIdentifier = 171; }
        if (detectedCountryName == "CHE") { countryIdentifier = 172; }
        if (detectedCountryName == "SYR") { countryIdentifier = 173; }
        if (detectedCountryName == "TWN") { countryIdentifier = 174; }
        if (detectedCountryName == "TJK") { countryIdentifier = 175; }
        if (detectedCountryName == "TZA") { countryIdentifier = 176; }
        if (detectedCountryName == "THA") { countryIdentifier = 177; }
        if (detectedCountryName == "TLS") { countryIdentifier = 178; }
        if (detectedCountryName == "TGO") { countryIdentifier = 179; }
        if (detectedCountryName == "TON") { countryIdentifier = 180; }
        if (detectedCountryName == "TTO") { countryIdentifier = 181; }
        if (detectedCountryName == "TUN") { countryIdentifier = 182; }
        if (detectedCountryName == "TUR") { countryIdentifier = 183; }
        if (detectedCountryName == "TKM") { countryIdentifier = 184; }
        if (detectedCountryName == "TUV") { countryIdentifier = 185; }
        if (detectedCountryName == "UGA") { countryIdentifier = 186; }
        if (detectedCountryName == "UKR") { countryIdentifier = 187; }
        if (detectedCountryName == "ARE") { countryIdentifier = 188; }
        if (detectedCountryName == "GBR") { countryIdentifier = 189; }
        if (detectedCountryName == "USA") { countryIdentifier = 190; }
        if (detectedCountryName == "URY") { countryIdentifier = 191; }
        if (detectedCountryName == "UZB") { countryIdentifier = 192; }
        if (detectedCountryName == "VUT") { countryIdentifier = 193; }
        if (detectedCountryName == "VAT") { countryIdentifier = 194; }
        if (detectedCountryName == "VEN") { countryIdentifier = 195; }
        if (detectedCountryName == "VNM") { countryIdentifier = 196; }
        if (detectedCountryName == "YEM") { countryIdentifier = 197; }
        if (detectedCountryName == "ZMB") { countryIdentifier = 198; }
        if (detectedCountryName == "ZWE") { countryIdentifier = 199; }
    }
}
