var OxOfe42=["onerror","onload","onclick","btnCancel","btnOK","onkeyup","txtHSB_Hue","onkeypress","txtHSB_Saturation","txtHSB_Brightness","txtRGB_Red","txtRGB_Green","txtRGB_Blue","txtHex","btnWebSafeColor","rdoHSB_Hue","rdoHSB_Saturation","rdoHSB_Brightness","rdoRGB_Red","rdoRGB_Green","rdoRGB_Blue","onmousemove","onmousedown","onmouseup","{format}","length","\x5C{","\x5C}","BadNumber","A number between {0} and {1} is required. Closest value inserted.","Title","Color Picker","SelectAColor","Select a color:","OKButton","OK","CancelButton","Cancel","AboutButton","About","Recent","WebSafeWarning","Warning: not a web safe color","WebSafeClick","Click to select web safe color","HsbHue","H:","HsbHueTooltip","Hue","HsbHueUnit","%","HsbSaturation","S:","HsbSaturationTooltip","Saturation","HsbSaturationUnit","HsbBrightness","B:","HsbBrightnessTooltip","Brightness","HsbBrightnessUnit","RgbRed","R:","RgbRedTooltip","Red","RgbGreen","G:","RgbGreenTooltip","Green","RgbBlue","RgbBlueTooltip","Blue","Hex","#","RecentTooltip","Recent:","\x0D\x0ALewies Color Pickerversion 1.1\x0D\x0A\x0D\x0AThis form was created by Lewis Moten in May of 2004.\x0D\x0AIt simulates the color picker in a popular graphics application.\x0D\x0AIt gives users a visual way to choose colors from a large and dynamic palette.\x0D\x0A\x0D\x0AVisit the authors web page?\x0D\x0Awww.lewismoten.com\x0D\x0A","UNDEFINED","FFFFFF","value","checked","ColorMode","ColorType","RecentColors","","pnlRecent","all","border","style","0px","backgroundColor","srcElement","display","none","title","innerHTML","backgroundPosition","px ","px","000000","zIndex","01234567879","keyCode","abcdef","01234567879ABCDEF","closeeditordialog","close","returnValue","0123456789ABCDEFabcdef","0","id","pnlGradient_Top","pnlVertical_Top","top","opacity","filters","backgroundImage","url(Load.ashx?type=image\x26file=cpie_GradientPositionDark.gif)","url(Load.ashx?type=image\x26file=cpie_GradientPositionLight.gif)","cancelBubble","clientX","clientY","className","GradientNormal","button","GradientFullScreen","=","; path=/;"," expires=",";","cookie","00336699CCFF","0x","do_select","frm","__cphex"];var POSITIONADJUSTX=21;var POSITIONADJUSTY=46;var POSITIONADJUSTZ=43;var msg= new Object();window[OxOfe42[0]]=alert;var ColorMode=1;var GradientPositionDark= new Boolean(false);var frm= new Object();window[OxOfe42[1]]=window_load;function initialize(){frm[OxOfe42[3]][OxOfe42[2]]=btnCancel_Click;frm[OxOfe42[4]][OxOfe42[2]]=btnOK_Click;frm[OxOfe42[6]][OxOfe42[5]]=Hsb_Changed;frm[OxOfe42[6]][OxOfe42[7]]=validateNumber;frm[OxOfe42[8]][OxOfe42[5]]=Hsb_Changed;frm[OxOfe42[8]][OxOfe42[7]]=validateNumber;frm[OxOfe42[9]][OxOfe42[5]]=Hsb_Changed;frm[OxOfe42[9]][OxOfe42[7]]=validateNumber;frm[OxOfe42[10]][OxOfe42[5]]=Rgb_Changed;frm[OxOfe42[10]][OxOfe42[7]]=validateNumber;frm[OxOfe42[11]][OxOfe42[5]]=Rgb_Changed;frm[OxOfe42[11]][OxOfe42[7]]=validateNumber;frm[OxOfe42[12]][OxOfe42[5]]=Rgb_Changed;frm[OxOfe42[12]][OxOfe42[7]]=validateNumber;frm[OxOfe42[13]][OxOfe42[5]]=Hex_Changed;frm[OxOfe42[13]][OxOfe42[7]]=validateHex;frm[OxOfe42[14]][OxOfe42[2]]=btnWebSafeColor_Click;frm[OxOfe42[15]][OxOfe42[2]]=rdoHsb_Hue_Click;frm[OxOfe42[16]][OxOfe42[2]]=rdoHsb_Saturation_Click;frm[OxOfe42[17]][OxOfe42[2]]=rdoHsb_Brightness_Click;frm[OxOfe42[18]][OxOfe42[2]]=rdoRgb_Red_Click;frm[OxOfe42[19]][OxOfe42[2]]=rdoRgb_Green_Click;frm[OxOfe42[20]][OxOfe42[2]]=rdoRgb_Blue_Click;pnlGradient_Top[OxOfe42[2]]=pnlGradient_Top_Click;pnlGradient_Top[OxOfe42[21]]=pnlGradient_Top_MouseMove;pnlGradient_Top[OxOfe42[22]]=pnlGradient_Top_MouseDown;pnlGradient_Top[OxOfe42[23]]=pnlGradient_Top_MouseUp;pnlVertical_Top[OxOfe42[2]]=pnlVertical_Top_Click;pnlVertical_Top[OxOfe42[21]]=pnlVertical_Top_MouseMove;pnlVertical_Top[OxOfe42[22]]=pnlVertical_Top_MouseDown;pnlVertical_Top[OxOfe42[23]]=pnlVertical_Top_MouseUp;pnlWebSafeColor[OxOfe42[2]]=btnWebSafeColor_Click;pnlWebSafeColorBorder[OxOfe42[2]]=btnWebSafeColor_Click;pnlOldColor[OxOfe42[2]]=pnlOldClick_Click;lblHSB_Hue[OxOfe42[2]]=rdoHsb_Hue_Click;lblHSB_Saturation[OxOfe42[2]]=rdoHsb_Saturation_Click;lblHSB_Brightness[OxOfe42[2]]=rdoHsb_Brightness_Click;lblRGB_Red[OxOfe42[2]]=rdoRgb_Red_Click;lblRGB_Green[OxOfe42[2]]=rdoRgb_Green_Click;lblRGB_Blue[OxOfe42[2]]=rdoRgb_Blue_Click;pnlGradient_Top.focus();} ;function formatString(Ox2b2){if(!Ox2b2){return OxOfe42[24];} ;for(var i=1;i<arguments[OxOfe42[25]];i++){Ox2b2=Ox2b2.replace( new RegExp(OxOfe42[26]+(i-1)+OxOfe42[27]),arguments[i]);} ;return Ox2b2;} ;function AddValue(Ox11a,Ox4f){Ox4f=Ox4f.toLowerCase();for(var i=0;i<Ox11a[OxOfe42[25]];i++){if(Ox11a[i]==Ox4f){return ;} ;} ;Ox11a[Ox11a[OxOfe42[25]]]=Ox4f;} ;function SniffLanguage(Ox11){} ;function LoadLanguage(){msg[OxOfe42[28]]=OxOfe42[29];msg[OxOfe42[30]]=OxOfe42[31];msg[OxOfe42[32]]=OxOfe42[33];msg[OxOfe42[34]]=OxOfe42[35];msg[OxOfe42[36]]=OxOfe42[37];msg[OxOfe42[38]]=OxOfe42[39];msg[OxOfe42[40]]=OxOfe42[40];msg[OxOfe42[41]]=OxOfe42[42];msg[OxOfe42[43]]=OxOfe42[44];msg[OxOfe42[45]]=OxOfe42[46];msg[OxOfe42[47]]=OxOfe42[48];msg[OxOfe42[49]]=OxOfe42[50];msg[OxOfe42[51]]=OxOfe42[52];msg[OxOfe42[53]]=OxOfe42[54];msg[OxOfe42[55]]=OxOfe42[50];msg[OxOfe42[56]]=OxOfe42[57];msg[OxOfe42[58]]=OxOfe42[59];msg[OxOfe42[60]]=OxOfe42[50];msg[OxOfe42[61]]=OxOfe42[62];msg[OxOfe42[63]]=OxOfe42[64];msg[OxOfe42[65]]=OxOfe42[66];msg[OxOfe42[67]]=OxOfe42[68];msg[OxOfe42[69]]=OxOfe42[57];msg[OxOfe42[70]]=OxOfe42[71];msg[OxOfe42[72]]=OxOfe42[73];msg[OxOfe42[74]]=OxOfe42[75];msg[OxOfe42[39]]=OxOfe42[76];} ;function localize(){} ;function window_load(){frm=frmColorPicker;LoadLanguage();localize();initialize();var hex=OxOfe42[77];if(hex==OxOfe42[77]){hex=OxOfe42[78];} ;if(hex[OxOfe42[25]]==7){hex=hex.substr(1,6);} ;frm[OxOfe42[13]][OxOfe42[79]]=hex;Hex_Changed();hex=Form_Get_Hex();SetBg(pnlOldColor,hex);frm[OxOfe42[82]][ new Number(GetCookie(OxOfe42[81])||0)][OxOfe42[80]]=true;ColorMode_Changed();var Ox2a8=GetCookie(OxOfe42[83])||OxOfe42[84];var Ox2b8=msg[OxOfe42[74]];for(var i=1;i<33;i++){if(Ox2a8[OxOfe42[25]]/6>=i){hex=Ox2a8.substr((i-1)*6,6);var Ox2b9=HexToRgb(hex);var title=formatString(msg.RecentTooltip,hex,Ox2b9[0],Ox2b9[1],Ox2b9[2]);SetBg(document[OxOfe42[86]][OxOfe42[85]+i],hex);SetTitle(document[OxOfe42[86]][OxOfe42[85]+i],title);document[OxOfe42[86]][OxOfe42[85]+i][OxOfe42[2]]=pnlRecent_Click;} else {document[OxOfe42[86]][OxOfe42[85]+i][OxOfe42[88]][OxOfe42[87]]=OxOfe42[89];} ;} ;} ;function pnlRecent_Click(){frm[OxOfe42[13]][OxOfe42[79]]=event[OxOfe42[91]][OxOfe42[88]][OxOfe42[90]].substr(1,6).toUpperCase();Hex_Changed();} ;function pnlOldClick_Click(){frm[OxOfe42[13]][OxOfe42[79]]=pnlOldColor[OxOfe42[88]][OxOfe42[90]].substr(1,6).toUpperCase();Hex_Changed();} ;function rdoHsb_Hue_Click(){frm[OxOfe42[15]][OxOfe42[80]]=true;ColorMode_Changed();} ;function rdoHsb_Saturation_Click(){frm[OxOfe42[16]][OxOfe42[80]]=true;ColorMode_Changed();} ;function rdoHsb_Brightness_Click(){frm[OxOfe42[17]][OxOfe42[80]]=true;ColorMode_Changed();} ;function rdoRgb_Red_Click(){frm[OxOfe42[18]][OxOfe42[80]]=true;ColorMode_Changed();} ;function rdoRgb_Green_Click(){frm[OxOfe42[19]][OxOfe42[80]]=true;ColorMode_Changed();} ;function rdoRgb_Blue_Click(){frm[OxOfe42[20]][OxOfe42[80]]=true;ColorMode_Changed();} ;function Hide(){for(var i=0;i<arguments[OxOfe42[25]];i++){arguments[i][OxOfe42[88]][OxOfe42[92]]=OxOfe42[93];} ;} ;function Show(){for(var i=0;i<arguments[OxOfe42[25]];i++){arguments[i][OxOfe42[88]][OxOfe42[92]]=OxOfe42[84];} ;} ;function SetValue(){for(var i=0;i<arguments[OxOfe42[25]];i+=2){arguments[i][OxOfe42[79]]=arguments[i+1];} ;} ;function SetTitle(){for(var i=0;i<arguments[OxOfe42[25]];i+=2){arguments[i][OxOfe42[94]]=arguments[i+1];} ;} ;function SetHTML(){for(var i=0;i<arguments[OxOfe42[25]];i+=2){arguments[i][OxOfe42[95]]=arguments[i+1];} ;} ;function SetBg(){for(var i=0;i<arguments[OxOfe42[25]];i+=2){arguments[i][OxOfe42[88]][OxOfe42[90]]=OxOfe42[73]+arguments[i+1];} ;} ;function SetBgPosition(){for(var i=0;i<arguments[OxOfe42[25]];i+=3){arguments[i][OxOfe42[88]][OxOfe42[96]]=arguments[i+1]+OxOfe42[97]+arguments[i+2]+OxOfe42[98];} ;} ;function ColorMode_Changed(){for(var i=0;i<6;i++){if(frm[OxOfe42[82]][i][OxOfe42[80]]){ColorMode=i;} ;} ;SetCookie(OxOfe42[81],ColorMode,60*60*24*365);Hide(pnlGradientHsbHue_Hue,pnlGradientHsbHue_Black,pnlGradientHsbHue_White,pnlVerticalHsbHue_Background,pnlVerticalHsbSaturation_Hue,pnlVerticalHsbSaturation_White,pnlVerticalHsbBrightness_Hue,pnlVerticalHsbBrightness_Black,pnlVerticalRgb_Start,pnlVerticalRgb_End,pnlGradientRgb_Base,pnlGradientRgb_Invert,pnlGradientRgb_Overlay1,pnlGradientRgb_Overlay2);switch(ColorMode){case 0:Show(pnlGradientHsbHue_Hue,pnlGradientHsbHue_Black,pnlGradientHsbHue_White,pnlVerticalHsbHue_Background);Hsb_Changed();break ;;case 1:Show(pnlVerticalHsbSaturation_Hue,pnlVerticalHsbSaturation_White,pnlGradientRgb_Base,pnlGradientRgb_Overlay1,pnlGradientRgb_Overlay2);SetBgPosition(pnlGradientRgb_Base,0,0);SetBg(pnlGradientRgb_Overlay1,OxOfe42[78],pnlGradientRgb_Overlay2,OxOfe42[99]);pnlGradientRgb_Overlay1[OxOfe42[88]][OxOfe42[100]]=5;pnlGradientRgb_Overlay2[OxOfe42[88]][OxOfe42[100]]=6;Hsb_Changed();break ;;case 2:Show(pnlVerticalHsbBrightness_Hue,pnlVerticalHsbBrightness_Black,pnlGradientRgb_Base,pnlGradientRgb_Overlay1,pnlGradientRgb_Overlay2);SetBgPosition(pnlGradientRgb_Base,0,0);SetBg(pnlGradientRgb_Overlay1,OxOfe42[99],pnlGradientRgb_Overlay2,OxOfe42[78]);pnlGradientRgb_Overlay1[OxOfe42[88]][OxOfe42[100]]=6;pnlGradientRgb_Overlay2[OxOfe42[88]][OxOfe42[100]]=5;Hsb_Changed();break ;;case 3:Show(pnlVerticalRgb_Start,pnlVerticalRgb_End,pnlGradientRgb_Base,pnlGradientRgb_Invert);SetBgPosition(pnlGradientRgb_Base,256,0,pnlGradientRgb_Invert,256,0);Rgb_Changed();break ;;case 4:Show(pnlVerticalRgb_Start,pnlVerticalRgb_End,pnlGradientRgb_Base,pnlGradientRgb_Invert);SetBgPosition(pnlGradientRgb_Base,0,256,pnlGradientRgb_Invert,0,256);Rgb_Changed();break ;;case 5:Show(pnlVerticalRgb_Start,pnlVerticalRgb_End,pnlGradientRgb_Base,pnlGradientRgb_Invert);SetBgPosition(pnlGradientRgb_Base,256,256,pnlGradientRgb_Invert,256,256);Rgb_Changed();break ;;default:break ;;} ;} ;function btnWebSafeColor_Click(){var Ox2b9=HexToRgb(frm[OxOfe42[13]].value);Ox2b9=RgbToWebSafeRgb(Ox2b9);frm[OxOfe42[13]][OxOfe42[79]]=RgbToHex(Ox2b9);Hex_Changed();} ;function checkWebSafe(){var Ox2b9=Form_Get_Rgb();if(RgbIsWebSafe(Ox2b9)){Hide(frm.btnWebSafeColor,pnlWebSafeColor,pnlWebSafeColorBorder);} else {Ox2b9=RgbToWebSafeRgb(Ox2b9);SetBg(pnlWebSafeColor,RgbToHex(Ox2b9));Show(frm.btnWebSafeColor,pnlWebSafeColor,pnlWebSafeColorBorder);} ;} ;function validateNumber(){var Ox2ce=String.fromCharCode(event.keyCode);if(IgnoreKey()){return ;} ;if(OxOfe42[101].indexOf(Ox2ce)!=-1){return ;} ;event[OxOfe42[102]]=0;} ;function validateHex(){if(IgnoreKey()){return ;} ;var Ox2ce=String.fromCharCode(event.keyCode);if(OxOfe42[103].indexOf(Ox2ce)!=-1){event[OxOfe42[102]]=Ox2ce.toUpperCase().charCodeAt(0);return ;} ;if(OxOfe42[104].indexOf(Ox2ce)!=-1){return ;} ;event[OxOfe42[102]]=0;} ;function IgnoreKey(){var Ox2ce=String.fromCharCode(event.keyCode);var Ox2d1= new Array(0,8,9,13,27);if(Ox2ce==null){return true;} ;for(var i=0;i<5;i++){if(event[OxOfe42[102]]==Ox2d1[i]){return true;} ;} ;return false;} ;function btnCancel_Click(){(top[OxOfe42[105]]||top[OxOfe42[106]])();} ;function btnOK_Click(){var hex= new String(frm[OxOfe42[13]].value);try{window[OxOfe42[107]]=hex;} catch(e){} ;recent=GetCookie(OxOfe42[83])||OxOfe42[84];for(var i=0;i<recent[OxOfe42[25]];i+=6){if(recent.substr(i,6)==hex){recent=recent.substr(0,i)+recent.substr(i+6);i-=6;} ;} ;if(recent[OxOfe42[25]]>31*6){recent=recent.substr(0,31*6);} ;recent=frm[OxOfe42[13]][OxOfe42[79]]+recent;SetCookie(OxOfe42[83],recent,60*60*24*365);(top[OxOfe42[105]]||top[OxOfe42[106]])();} ;function SetGradientPosition(x,y){x=x-POSITIONADJUSTX+5;y=y-POSITIONADJUSTY+5;x-=7;y-=27;x=x<0?0:x>255?255:x;y=y<0?0:y>255?255:y;SetBgPosition(pnlGradientPosition,x-5,y-5);switch(ColorMode){case 0:var Ox2d5= new Array(0,0,0);Ox2d5[1]=x/255;Ox2d5[2]=1-(y/255);frm[OxOfe42[8]][OxOfe42[79]]=Math.round(Ox2d5[1]*100);frm[OxOfe42[9]][OxOfe42[79]]=Math.round(Ox2d5[2]*100);Hsb_Changed();break ;;case 1:var Ox2d5= new Array(0,0,0);Ox2d5[0]=x/255;Ox2d5[2]=1-(y/255);frm[OxOfe42[6]][OxOfe42[79]]=Ox2d5[0]==1?0:Math.round(Ox2d5[0]*360);frm[OxOfe42[9]][OxOfe42[79]]=Math.round(Ox2d5[2]*100);Hsb_Changed();break ;;case 2:var Ox2d5= new Array(0,0,0);Ox2d5[0]=x/255;Ox2d5[1]=1-(y/255);frm[OxOfe42[6]][OxOfe42[79]]=Ox2d5[0]==1?0:Math.round(Ox2d5[0]*360);frm[OxOfe42[8]][OxOfe42[79]]=Math.round(Ox2d5[1]*100);Hsb_Changed();break ;;case 3:var Ox2b9= new Array(0,0,0);Ox2b9[1]=255-y;Ox2b9[2]=x;frm[OxOfe42[11]][OxOfe42[79]]=Ox2b9[1];frm[OxOfe42[12]][OxOfe42[79]]=Ox2b9[2];Rgb_Changed();break ;;case 4:var Ox2b9= new Array(0,0,0);Ox2b9[0]=255-y;Ox2b9[2]=x;frm[OxOfe42[10]][OxOfe42[79]]=Ox2b9[0];frm[OxOfe42[12]][OxOfe42[79]]=Ox2b9[2];Rgb_Changed();break ;;case 5:var Ox2b9= new Array(0,0,0);Ox2b9[0]=x;Ox2b9[1]=255-y;frm[OxOfe42[10]][OxOfe42[79]]=Ox2b9[0];frm[OxOfe42[11]][OxOfe42[79]]=Ox2b9[1];Rgb_Changed();break ;;} ;} ;function Hex_Changed(){var hex=Form_Get_Hex();var Ox2b9=HexToRgb(hex);var Ox2d5=RgbToHsb(Ox2b9);Form_Set_Rgb(Ox2b9);Form_Set_Hsb(Ox2d5);SetBg(pnlNewColor,hex);SetupCursors();SetupGradients();checkWebSafe();} ;function Rgb_Changed(){var Ox2b9=Form_Get_Rgb();var Ox2d5=RgbToHsb(Ox2b9);var hex=RgbToHex(Ox2b9);Form_Set_Hsb(Ox2d5);Form_Set_Hex(hex);SetBg(pnlNewColor,hex);SetupCursors();SetupGradients();checkWebSafe();} ;function Hsb_Changed(){var Ox2d5=Form_Get_Hsb();var Ox2b9=HsbToRgb(Ox2d5);var hex=RgbToHex(Ox2b9);Form_Set_Rgb(Ox2b9);Form_Set_Hex(hex);SetBg(pnlNewColor,hex);SetupCursors();SetupGradients();checkWebSafe();} ;function Form_Set_Hex(hex){frm[OxOfe42[13]][OxOfe42[79]]=hex;} ;function Form_Get_Hex(){var hex= new String(frm[OxOfe42[13]].value);for(var i=0;i<hex[OxOfe42[25]];i++){if(OxOfe42[108].indexOf(hex.substr(i,1))==-1){hex=OxOfe42[99];frm[OxOfe42[13]][OxOfe42[79]]=hex;alert(formatString(msg.BadNumber,OxOfe42[99],OxOfe42[78]));break ;} ;} ;while(hex[OxOfe42[25]]<6){hex=OxOfe42[109]+hex;} ;return hex;} ;function Form_Get_Hsb(){var Ox2d5= new Array(0,0,0);Ox2d5[0]= new Number(frm[OxOfe42[6]].value)/360;Ox2d5[1]= new Number(frm[OxOfe42[8]].value)/100;Ox2d5[2]= new Number(frm[OxOfe42[9]].value)/100;if(Ox2d5[0]>1||isNaN(Ox2d5[0])){Ox2d5[0]=1;frm[OxOfe42[6]][OxOfe42[79]]=360;alert(formatString(msg.BadNumber,0,360));} ;if(Ox2d5[1]>1||isNaN(Ox2d5[1])){Ox2d5[1]=1;frm[OxOfe42[8]][OxOfe42[79]]=100;alert(formatString(msg.BadNumber,0,100));} ;if(Ox2d5[2]>1||isNaN(Ox2d5[2])){Ox2d5[2]=1;frm[OxOfe42[9]][OxOfe42[79]]=100;alert(formatString(msg.BadNumber,0,100));} ;return Ox2d5;} ;function Form_Set_Hsb(Ox2d5){SetValue(frm.txtHSB_Hue,Math.round(Ox2d5[0]*360),frm.txtHSB_Saturation,Math.round(Ox2d5[1]*100),frm.txtHSB_Brightness,Math.round(Ox2d5[2]*100));} ;function Form_Get_Rgb(){var Ox2b9= new Array(0,0,0);Ox2b9[0]= new Number(frm[OxOfe42[10]].value);Ox2b9[1]= new Number(frm[OxOfe42[11]].value);Ox2b9[2]= new Number(frm[OxOfe42[12]].value);if(Ox2b9[0]>255||isNaN(Ox2b9[0])||Ox2b9[0]!=Math.round(Ox2b9[0])){Ox2b9[0]=255;frm[OxOfe42[10]][OxOfe42[79]]=255;alert(formatString(msg.BadNumber,0,255));} ;if(Ox2b9[1]>255||isNaN(Ox2b9[1])||Ox2b9[1]!=Math.round(Ox2b9[1])){Ox2b9[1]=255;frm[OxOfe42[11]][OxOfe42[79]]=255;alert(formatString(msg.BadNumber,0,255));} ;if(Ox2b9[2]>255||isNaN(Ox2b9[2])||Ox2b9[2]!=Math.round(Ox2b9[2])){Ox2b9[2]=255;frm[OxOfe42[12]][OxOfe42[79]]=255;alert(formatString(msg.BadNumber,0,255));} ;return Ox2b9;} ;function Form_Set_Rgb(Ox2b9){frm[OxOfe42[10]][OxOfe42[79]]=Ox2b9[0];frm[OxOfe42[11]][OxOfe42[79]]=Ox2b9[1];frm[OxOfe42[12]][OxOfe42[79]]=Ox2b9[2];} ;function SetupCursors(){var Ox2d5=Form_Get_Hsb();var Ox2b9=Form_Get_Rgb();if(RgbToYuv(Ox2b9)[0]>=0.5){SetGradientPositionDark();} else {SetGradientPositionLight();} ;if(event[OxOfe42[91]]!=null){if(event[OxOfe42[91]][OxOfe42[110]]==OxOfe42[111]){return ;} ;if(event[OxOfe42[91]][OxOfe42[110]]==OxOfe42[112]){return ;} ;} ;var x;var y;var z;if(ColorMode>=0&&ColorMode<=2){for(var i=0;i<3;i++){Ox2d5[i]*=255;} ;} ;switch(ColorMode){case 0:x=Ox2d5[1];y=Ox2d5[2];z=Ox2d5[0]==0?1:Ox2d5[0];break ;;case 1:x=Ox2d5[0]==0?1:Ox2d5[0];y=Ox2d5[2];z=Ox2d5[1];break ;;case 2:x=Ox2d5[0]==0?1:Ox2d5[0];y=Ox2d5[1];z=Ox2d5[2];break ;;case 3:x=Ox2b9[2];y=Ox2b9[1];z=Ox2b9[0];break ;;case 4:x=Ox2b9[2];y=Ox2b9[0];z=Ox2b9[1];break ;;case 5:x=Ox2b9[0];y=Ox2b9[1];z=Ox2b9[2];break ;;} ;y=255-y;z=255-z;SetBgPosition(pnlGradientPosition,x-5,y-5);pnlVerticalPosition[OxOfe42[88]][OxOfe42[113]]=(z+27)+OxOfe42[98];} ;function SetupGradients(){var Ox2d5=Form_Get_Hsb();var Ox2b9=Form_Get_Rgb();switch(ColorMode){case 0:SetBg(pnlGradientHsbHue_Hue,RgbToHex(HueToRgb(Ox2d5[0])));break ;;case 1:var b= new Array();for(var i=0;i<3;i++){b[i]=Math.round(Ox2d5[2]*255);} ;SetBg(pnlGradientHsbHue_Hue,RgbToHex(HueToRgb(Ox2d5[0])),pnlVerticalHsbSaturation_Hue,RgbToHex(HsbToRgb( new Array(Ox2d5[0],1,Ox2d5[2]))),pnlVerticalHsbSaturation_White,RgbToHex(b));pnlGradientRgb_Overlay1[OxOfe42[115]][0][OxOfe42[114]]=(100-Math.round(Ox2d5[1]*100));break ;;case 2:SetBg(pnlVerticalHsbBrightness_Hue,RgbToHex(HsbToRgb( new Array(Ox2d5[0],Ox2d5[1],1))));pnlGradientRgb_Overlay1[OxOfe42[115]][0][OxOfe42[114]]=(100-Math.round(Ox2d5[2]*100));break ;;case 3:pnlGradientRgb_Invert[OxOfe42[115]][3][OxOfe42[114]]=100-Math.round((Ox2b9[0]/255)*100);SetBg(pnlVerticalRgb_Start,RgbToHex( new Array(0xFF,Ox2b9[1],Ox2b9[2])),pnlVerticalRgb_End,RgbToHex( new Array(0x00,Ox2b9[1],Ox2b9[2])));break ;;case 4:pnlGradientRgb_Invert[OxOfe42[115]][3][OxOfe42[114]]=100-Math.round((Ox2b9[1]/255)*100);SetBg(pnlVerticalRgb_Start,RgbToHex( new Array(Ox2b9[0],0xFF,Ox2b9[2])),pnlVerticalRgb_End,RgbToHex( new Array(Ox2b9[0],0x00,Ox2b9[2])));break ;;case 5:pnlGradientRgb_Invert[OxOfe42[115]][3][OxOfe42[114]]=100-Math.round((Ox2b9[2]/255)*100);SetBg(pnlVerticalRgb_Start,RgbToHex( new Array(Ox2b9[0],Ox2b9[1],0xFF)),pnlVerticalRgb_End,RgbToHex( new Array(Ox2b9[0],Ox2b9[1],0x00)));break ;;default:;} ;} ;function SetGradientPositionDark(){if(GradientPositionDark){return ;} ;GradientPositionDark=true;pnlGradientPosition[OxOfe42[88]][OxOfe42[116]]=OxOfe42[117];} ;function SetGradientPositionLight(){if(!GradientPositionDark){return ;} ;GradientPositionDark=false;pnlGradientPosition[OxOfe42[88]][OxOfe42[116]]=OxOfe42[118];} ;function pnlGradient_Top_Click(){event[OxOfe42[119]]=true;SetGradientPosition(event[OxOfe42[120]]-5,event[OxOfe42[121]]-5);pnlGradient_Top[OxOfe42[122]]=OxOfe42[123];} ;function pnlGradient_Top_MouseMove(){event[OxOfe42[119]]=true;if(event[OxOfe42[124]]!=1){return ;} ;SetGradientPosition(event[OxOfe42[120]]-5,event[OxOfe42[121]]-5);} ;function pnlGradient_Top_MouseDown(){event[OxOfe42[119]]=true;SetGradientPosition(event[OxOfe42[120]]-5,event[OxOfe42[121]]-5);pnlGradient_Top[OxOfe42[122]]=OxOfe42[125];} ;function pnlGradient_Top_MouseUp(){event[OxOfe42[119]]=true;SetGradientPosition(event[OxOfe42[120]]-5,event[OxOfe42[121]]-5);pnlGradient_Top[OxOfe42[122]]=OxOfe42[123];} ;function Document_MouseUp(){event[OxOfe42[119]]=true;pnlGradient_Top[OxOfe42[122]]=OxOfe42[123];} ;function SetVerticalPosition(z){var z=z-POSITIONADJUSTZ;if(z<27){z=27;} ;if(z>282){z=282;} ;pnlVerticalPosition[OxOfe42[88]][OxOfe42[113]]=z+OxOfe42[98];z=1-((z-27)/255);switch(ColorMode){case 0:if(z==1){z=0;} ;frm[OxOfe42[6]][OxOfe42[79]]=Math.round(z*360);Hsb_Changed();break ;;case 1:frm[OxOfe42[8]][OxOfe42[79]]=Math.round(z*100);Hsb_Changed();break ;;case 2:frm[OxOfe42[9]][OxOfe42[79]]=Math.round(z*100);Hsb_Changed();break ;;case 3:frm[OxOfe42[10]][OxOfe42[79]]=Math.round(z*255);Rgb_Changed();break ;;case 4:frm[OxOfe42[11]][OxOfe42[79]]=Math.round(z*255);Rgb_Changed();break ;;case 5:frm[OxOfe42[12]][OxOfe42[79]]=Math.round(z*255);Rgb_Changed();break ;;} ;} ;function pnlVertical_Top_Click(){SetVerticalPosition(event[OxOfe42[121]]-5);event[OxOfe42[119]]=true;} ;function pnlVertical_Top_MouseMove(){if(event[OxOfe42[124]]!=1){return ;} ;SetVerticalPosition(event[OxOfe42[121]]-5);event[OxOfe42[119]]=true;} ;function pnlVertical_Top_MouseDown(){SetVerticalPosition(event[OxOfe42[121]]-5);event[OxOfe42[119]]=true;} ;function pnlVertical_Top_MouseUp(){SetVerticalPosition(event[OxOfe42[121]]-5);event[OxOfe42[119]]=true;} ;function SetCookie(name,Ox4f,Ox56){var Ox57=name+OxOfe42[126]+escape(Ox4f)+OxOfe42[127];if(Ox56){var Ox58= new Date();Ox58.setSeconds(Ox58.getSeconds()+Ox56);Ox57+=OxOfe42[128]+Ox58.toUTCString()+OxOfe42[129];} ;document[OxOfe42[130]]=Ox57;} ;function GetCookie(name){var Ox5a=document[OxOfe42[130]].split(OxOfe42[129]);for(var i=0;i<Ox5a[OxOfe42[25]];i++){var Ox5b=Ox5a[i].split(OxOfe42[126]);if(name==Ox5b[0].replace(/\s/g,OxOfe42[84])){return unescape(Ox5b[1]);} ;} ;} ;function GetCookieDictionary(){var Ox12b={};var Ox5a=document[OxOfe42[130]].split(OxOfe42[129]);for(var i=0;i<Ox5a[OxOfe42[25]];i++){var Ox5b=Ox5a[i].split(OxOfe42[126]);Ox12b[Ox5b[0].replace(/\s/g,OxOfe42[84])]=unescape(Ox5b[1]);} ;return Ox12b;} ;function RgbIsWebSafe(Ox2b9){var hex=RgbToHex(Ox2b9);for(var i=0;i<3;i++){if(OxOfe42[131].indexOf(hex.substr(i*2,2))==-1){return false;} ;} ;return true;} ;function RgbToWebSafeRgb(Ox2b9){var Ox2ef= new Array(Ox2b9[0],Ox2b9[1],Ox2b9[2]);if(RgbIsWebSafe(Ox2b9)){return Ox2ef;} ;var Ox2f0= new Array(0x00,0x33,0x66,0x99,0xCC,0xFF);for(var i=0;i<3;i++){for(var Ox25=1;Ox25<6;Ox25++){if(Ox2ef[i]>Ox2f0[Ox25-1]&&Ox2ef[i]<Ox2f0[Ox25]){if(Ox2ef[i]-Ox2f0[Ox25-1]>Ox2f0[Ox25]-Ox2ef[i]){Ox2ef[i]=Ox2f0[Ox25];} else {Ox2ef[i]=Ox2f0[Ox25-1];} ;break ;} ;} ;} ;return Ox2ef;} ;function RgbToYuv(Ox2b9){var Ox2f2= new Array();Ox2f2[0]=(Ox2b9[0]*0.299+Ox2b9[1]*0.587+Ox2b9[2]*0.114)/255;Ox2f2[1]=(Ox2b9[0]*-0.169+Ox2b9[1]*-0.332+Ox2b9[2]*0.500+128)/255;Ox2f2[2]=(Ox2b9[0]*0.500+Ox2b9[1]*-0.419+Ox2b9[2]*-0.0813+128)/255;return Ox2f2;} ;function RgbToHsb(Ox2b9){var Ox2f4= new Array(Ox2b9[0],Ox2b9[1],Ox2b9[2]);var Ox2f5= new Number(1);var Ox2f6= new Number(0);var Ox2f7= new Number(1);var Ox2d5= new Array(0,0,0);var Ox2f8= new Array();for(var i=0;i<3;i++){Ox2f4[i]=Ox2b9[i]/255;if(Ox2f4[i]<Ox2f5){Ox2f5=Ox2f4[i];} ;if(Ox2f4[i]>Ox2f6){Ox2f6=Ox2f4[i];} ;} ;Ox2f7=Ox2f6-Ox2f5;Ox2d5[2]=Ox2f6;if(Ox2f7==0){return Ox2d5;} ;Ox2d5[1]=Ox2f7/Ox2f6;for(var i=0;i<3;i++){Ox2f8[i]=(((Ox2f6-Ox2f4[i])/6)+(Ox2f7/2))/Ox2f7;} ;if(Ox2f4[0]==Ox2f6){Ox2d5[0]=Ox2f8[2]-Ox2f8[1];} else {if(Ox2f4[1]==Ox2f6){Ox2d5[0]=(1/3)+Ox2f8[0]-Ox2f8[2];} else {if(Ox2f4[2]==Ox2f6){Ox2d5[0]=(2/3)+Ox2f8[1]-Ox2f8[0];} ;} ;} ;if(Ox2d5[0]<0){Ox2d5[0]+=1;} else {if(Ox2d5[0]>1){Ox2d5[0]-=1;} ;} ;return Ox2d5;} ;function HsbToRgb(Ox2d5){var Ox2b9=HueToRgb(Ox2d5[0]);var Ox120=Ox2d5[2]*255;for(var i=0;i<3;i++){Ox2b9[i]=Ox2b9[i]*Ox2d5[2];Ox2b9[i]=((Ox2b9[i]-Ox120)*Ox2d5[1])+Ox120;Ox2b9[i]=Math.round(Ox2b9[i]);} ;return Ox2b9;} ;function RgbToHex(Ox2b9){var hex= new String();for(var i=0;i<3;i++){Ox2b9[2-i]=Math.round(Ox2b9[2-i]);hex=Ox2b9[2-i].toString(16)+hex;if(hex[OxOfe42[25]]%2==1){hex=OxOfe42[109]+hex;} ;} ;return hex.toUpperCase();} ;function HexToRgb(hex){var Ox2b9= new Array();for(var i=0;i<3;i++){Ox2b9[i]= new Number(OxOfe42[132]+hex.substr(i*2,2));} ;return Ox2b9;} ;function HueToRgb(Ox2fd){var Ox2fe=Ox2fd*360;var Ox2b9= new Array(0,0,0);var Ox2ff=(Ox2fe%60)/60;if(Ox2fe<60){Ox2b9[0]=255;Ox2b9[1]=Ox2ff*255;} else {if(Ox2fe<120){Ox2b9[1]=255;Ox2b9[0]=(1-Ox2ff)*255;} else {if(Ox2fe<180){Ox2b9[1]=255;Ox2b9[2]=Ox2ff*255;} else {if(Ox2fe<240){Ox2b9[2]=255;Ox2b9[1]=(1-Ox2ff)*255;} else {if(Ox2fe<300){Ox2b9[2]=255;Ox2b9[0]=Ox2ff*255;} else {if(Ox2fe<360){Ox2b9[0]=255;Ox2b9[2]=(1-Ox2ff)*255;} ;} ;} ;} ;} ;} ;return Ox2b9;} ;function CheckHexSelect(){if(window[OxOfe42[133]]&&window[OxOfe42[134]]&&frm[OxOfe42[13]]){var Oxdc=OxOfe42[73]+frm[OxOfe42[13]][OxOfe42[79]];if(Oxdc[OxOfe42[25]]==7){if(window[OxOfe42[135]]!=Oxdc){window[OxOfe42[135]]=Oxdc;window.do_select(Oxdc);} ;} ;} ;} ;setInterval(CheckHexSelect,10);