var OxO10c2=["stringSearch","stringReplace","MatchWholeWord","MatchCase","document","checked","length","value","Nothing to search.","selection","body","type","Control","rangeCount","userAgent","endContainer","endOffset","editor","text","Finished Searching the document. Would you like to start again from the top?","","textedit","[[WordNotFound]]","[[WordReplaced]] : ","Please use replace funtion."];var editwin=Window_GetDialogArguments(window);var stringSearch=Window_GetElement(window,OxO10c2[0],true);var stringReplace=Window_GetElement(window,OxO10c2[1],true);var MatchWholeWord=Window_GetElement(window,OxO10c2[2],true);var MatchCase=Window_GetElement(window,OxO10c2[3],true);var editdoc=editwin[OxO10c2[4]];function get_ie_matchtype(){var Ox311=0;var Ox312=0;var Ox313=0;if(MatchCase[OxO10c2[5]]){Ox312=4;} ;if(MatchWholeWord[OxO10c2[5]]){Ox313=2;} ;Ox311=Ox312+Ox313;return (Ox311);} ;function checkInputString(){if(stringSearch[OxO10c2[7]][OxO10c2[6]]<1){alert(OxO10c2[8]);return false;} else {return true;} ;} ;function IsMatchSearchValue(Ox24){if(!Ox24){return false;} ;if(stringSearch[OxO10c2[7]]==Ox24){return true;} ;if(MatchCase[OxO10c2[5]]){return false;} ;return stringSearch[OxO10c2[7]].toLowerCase()==Ox24.toLowerCase();} ;var _ie_range=null;function IE_Restore(){editwin.focus();if(_ie_range!=null){_ie_range.select();} ;} ;function IE_Save(){editwin.focus();_ie_range=editdoc[OxO10c2[9]].createRange();} ;function MoveToBodyStart(){if(Browser_UseIESelection()){range=document[OxO10c2[10]].createTextRange();range.collapse(true);range.select();IE_Save();} else {editwin.getSelection().collapse(editdoc.body,0);} ;} ;function DoFind(){if(Browser_UseIESelection()){IE_Restore();var Ox136=editdoc[OxO10c2[9]];if(Ox136[OxO10c2[11]]==OxO10c2[12]){MoveToBodyStart();} ;var Ox228=Ox136.createRange();Ox228.collapse(false);if(Ox228.findText(stringSearch.value,1000000000,get_ie_matchtype())){Ox228.select();IE_Save();return true;} ;} else {var Ox228;var Ox136=editwin.getSelection();if(Ox136[OxO10c2[13]]>0){Ox228=editwin.getSelection().getRangeAt(0);} ;if(navigator[OxO10c2[14]].match(/Trident/)){return editwin[OxO10c2[17]].FindText(editwin,{node:Ox228[OxO10c2[15]],offset:Ox228[OxO10c2[16]]},stringSearch.value,MatchCase.checked,MatchWholeWord.checked);} else {if(editwin.find(stringSearch.value,MatchCase.checked,false,false,MatchWholeWord.checked,false,false)){return true;} ;} ;} ;} ;function DoReplace(){if(Browser_UseIESelection()){IE_Restore();var Ox136=editdoc[OxO10c2[9]];if(Ox136[OxO10c2[11]]!=OxO10c2[12]){var Ox228=Ox136.createRange();if(IsMatchSearchValue(Ox228.text)){Ox228[OxO10c2[18]]=stringReplace[OxO10c2[7]];Ox228.collapse(false);IE_Save();return true;} ;} ;} else {var Ox136=editwin.getSelection();if(IsMatchSearchValue(Ox136.toString())){Ox136.deleteFromDocument();Ox136.getRangeAt(0).insertNode(editdoc.createTextNode(stringReplace.value));Ox136.getRangeAt(0).collapse(false);return true;} ;} ;return false;} ;function FindTxt(){if(!checkInputString()){return false;} ;while(true){if(DoFind()){return ;} ;if(!confirm(OxO10c2[19])){return ;} ;MoveToBodyStart();} ;} ;function ReplaceTxt(){if(!checkInputString()){return ;} ;DoReplace();FindTxt();} ;function ReplaceAllTxt(){if(!checkInputString()){return ;} ;var Ox31f=0;var msg=OxO10c2[20];MoveToBodyStart();if(Browser_UseIESelection()){var Ox136=editdoc[OxO10c2[9]];if(Ox136[OxO10c2[11]]==OxO10c2[12]){MoveToBodyStart();} ;var Ox320=Ox136.createRange();var Ox31f=0;var msg=OxO10c2[20];Ox320.expand(OxO10c2[21]);Ox320.collapse();Ox320.select();while(Ox320.findText(stringSearch.value,1000000000,get_ie_matchtype())){Ox320.select();Ox320[OxO10c2[18]]=stringReplace[OxO10c2[7]];Ox31f++;} ;if(Ox31f==0){msg=OxO10c2[22];} else {msg=OxO10c2[23]+Ox31f;} ;alert(msg);} else {if((stringReplace[OxO10c2[7]]).indexOf(stringSearch.value)==-1){DoFind();while(DoReplace()){Ox31f++;DoFind();FindTxt();} ;if(Ox31f==0){msg=OxO10c2[22];} else {msg=OxO10c2[23]+Ox31f;} ;alert(msg);} else {FindTxt();alert(OxO10c2[24]);} ;} ;} ;