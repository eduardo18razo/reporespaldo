var OxObf9b=["nodeName","INPUT","TEXTAREA","BUTTON","IMG","SELECT","TABLE","position","style","absolute","relative","|H1|H2|H3|H4|H5|H6|P|PRE|LI|TD|DIV|BLOCKQUOTE|DT|DD|TABLE|HR|IMG|","|","body","document","allanchors","anchor_name","editor","window","name","value","[[ValidName]]","options","length","anchors","OPTION","text","#","images","className","cetempAnchor","anchorname","","--\x3E"," ","trim","prototype"];function Element_IsBlockControl(element){var name=element[OxObf9b[0]];if(name==OxObf9b[1]){return true;} ;if(name==OxObf9b[2]){return true;} ;if(name==OxObf9b[3]){return true;} ;if(name==OxObf9b[4]){return true;} ;if(name==OxObf9b[5]){return true;} ;if(name==OxObf9b[6]){return true;} ;var Ox126=element[OxObf9b[8]][OxObf9b[7]];if(Ox126==OxObf9b[9]||Ox126==OxObf9b[10]){return true;} ;return false;} ;function Element_CUtil_IsBlock(Ox36f){var Ox370=OxObf9b[11];return (Ox36f!=null)&&(Ox370.indexOf(OxObf9b[12]+Ox36f[OxObf9b[0]]+OxObf9b[12])!=-1);} ;function Window_SelectElement(Ox1a8,element){if(Browser_UseIESelection()){if(Element_IsBlockControl(element)){var Ox31=Ox1a8[OxObf9b[14]][OxObf9b[13]].createControlRange();Ox31.add(element);Ox31.select();} else {var Ox228=Ox1a8[OxObf9b[14]][OxObf9b[13]].createTextRange();Ox228.moveToElementText(element);Ox228.select();} ;} else {var Ox228=Ox1a8[OxObf9b[14]].createRange();try{Ox228.selectNode(element);} catch(x){Ox228.selectNodeContents(element);} ;var Ox136=Ox1a8.getSelection();Ox136.removeAllRanges();Ox136.addRange(Ox228);} ;} ;var allanchors=Window_GetElement(window,OxObf9b[15],true);var anchor_name=Window_GetElement(window,OxObf9b[16],true);var obj=Window_GetDialogArguments(window);var editor=obj[OxObf9b[17]];var editwin=obj[OxObf9b[18]];var editdoc=obj[OxObf9b[14]];var name=obj[OxObf9b[19]];function insert_link(){var Ox375=anchor_name[OxObf9b[20]];var Ox376=/[^a-z\d]/i;Ox375=Ox375.trim();if(Ox376.test(Ox375)){alert(OxObf9b[21]);} else {Window_SetDialogReturnValue(window,Ox375);Window_CloseDialog(window);} ;} ;function updateList(){while(allanchors[OxObf9b[22]][OxObf9b[23]]!=0){allanchors[OxObf9b[22]].remove(allanchors.options(0));} ;if(Browser_IsWinIE()){for(var i=0;i<editdoc[OxObf9b[24]][OxObf9b[23]];i++){var Ox378=document.createElement(OxObf9b[25]);Ox378[OxObf9b[26]]=OxObf9b[27]+editdoc[OxObf9b[24]][i][OxObf9b[19]];Ox378[OxObf9b[20]]=editdoc[OxObf9b[24]][i][OxObf9b[19]];allanchors[OxObf9b[22]].add(Ox378);} ;} else {var Ox379=editdoc[OxObf9b[28]];if(Ox379){for(var Ox25=0;Ox25<Ox379[OxObf9b[23]];Ox25++){var img=Ox379[Ox25];if(img[OxObf9b[29]]==OxObf9b[30]){var Ox378=document.createElement(OxObf9b[25]);Ox378[OxObf9b[26]]=OxObf9b[27]+img.getAttribute(OxObf9b[31]);Ox378[OxObf9b[20]]=img.getAttribute(OxObf9b[31]);allanchors[OxObf9b[22]].add(Ox378);} ;} ;} ;} ;} ;function selectAnchor(Ox37b){editor.FocusDocument();for(var i=0;i<editdoc[OxObf9b[24]][OxObf9b[23]];i++){if(editdoc[OxObf9b[24]][i][OxObf9b[19]]==Ox37b){anchor_name[OxObf9b[20]]=Ox37b;Window_SelectElement(editwin,editdoc[OxObf9b[24]][i]);} ;} ;} ;if(name&&name!=OxObf9b[32]){name=name.replace(/[\s]*<!--[\s\S]*?-->[\s]*/g,OxObf9b[32]);name=name.replace(OxObf9b[33],OxObf9b[34]);anchor_name[OxObf9b[20]]=name;} ;updateList();String[OxObf9b[36]][OxObf9b[35]]=function (){return this.replace(/^\s*/,OxObf9b[32]).replace(/\s*$/,OxObf9b[32]);} ;