var OxO5d01=["is_spring_image","1","gid","zIndex","style","srcImg","documentElement","body","getBoundingClientRect","left","top","getBoxObjectFor","x","y","offsetWidth","offsetHeight","offsetLeft","offsetTop","offsetParent","R","width","px","height","M","spring_expand(\x27","id","\x27)","lastActiveElement","spring_collapse(\x27","display","none","parentNode","block","hidetip","src","url","className","spring_image_popup","void(0)","expand","collapse","onmouseout","onmouseover","onclick","tooltip","click","prototype","MouseEvents","ownerDocument","addEventListener","scroll","attachEvent","onscroll"];function hidetip(){} ;function render_spring_image(Ox29){var Ox324;if(Ox29.getAttribute(OxO5d01[0])==OxO5d01[1]){return ;} ;Ox29.setAttribute(OxO5d01[0],OxO5d01[1]);render_spring_image[OxO5d01[2]]=render_spring_image[OxO5d01[2]]||1;render_spring_image[OxO5d01[2]]++;function Ox325(){clearTimeout(this.M);render_spring_image[OxO5d01[2]]++;this[OxO5d01[4]][OxO5d01[3]]=1000000+render_spring_image[OxO5d01[2]];var Ox326=this[OxO5d01[5]];var Ox327,Ox328,Ox329,Ox32a;Ox329=Math.max(document[OxO5d01[6]].scrollTop,document[OxO5d01[7]].scrollTop);Ox32a=Math.max(document[OxO5d01[6]].scrollLeft,document[OxO5d01[7]].scrollLeft);if(Ox326[OxO5d01[8]]){Ox327=Ox326.getBoundingClientRect()[OxO5d01[9]];Ox328=Ox326.getBoundingClientRect()[OxO5d01[10]];} else {if(document[OxO5d01[11]]){Ox327=document.getBoxObjectFor(Ox326)[OxO5d01[12]]-Ox32a;Ox328=document.getBoxObjectFor(Ox326)[OxO5d01[13]]-Ox329;} else {var Ox32b=Ox32c(Ox326);Ox327=Ox32b[OxO5d01[12]]-Ox32a;Ox328=Ox32b[OxO5d01[13]]-Ox329;} ;} ;function Ox32c(element){var Ox32b={x:0,y:0,width:element[OxO5d01[14]],height:element[OxO5d01[15]]};while(element){Ox32b[OxO5d01[12]]+=element[OxO5d01[16]];Ox32b[OxO5d01[13]]+=element[OxO5d01[17]];element=element[OxO5d01[18]];} ;return Ox32b;} ;if(this[OxO5d01[19]]<1.35){this[OxO5d01[19]]+=0.1;this[OxO5d01[4]][OxO5d01[20]]=Math.floor(Ox326[OxO5d01[14]]*this[OxO5d01[19]])+OxO5d01[21];this[OxO5d01[4]][OxO5d01[22]]=Math.floor(Ox326[OxO5d01[15]]*this[OxO5d01[19]])+OxO5d01[21];Ox328=Math.floor(Ox328+Ox329-(this[OxO5d01[14]]-Ox326[OxO5d01[14]])/2)+OxO5d01[21];;;Ox327=Math.floor(Ox327+Ox32a-(this[OxO5d01[15]]-Ox326[OxO5d01[15]])/2)+OxO5d01[21];this[OxO5d01[4]][OxO5d01[10]]=Ox328;this[OxO5d01[4]][OxO5d01[9]]=Ox327;this[OxO5d01[23]]=setTimeout(OxO5d01[24]+this[OxO5d01[25]]+OxO5d01[26],20);} else {if(render_spring_image[OxO5d01[27]]!=this){this[OxO5d01[23]]=setTimeout(OxO5d01[28]+this[OxO5d01[25]]+OxO5d01[26],20);} ;} ;} ;function Ox32d(){clearTimeout(this.M);var Ox326=this[OxO5d01[5]];var Ox327,Ox328,Ox329,Ox32a;Ox329=Math.max(document[OxO5d01[6]].scrollTop,document[OxO5d01[7]].scrollTop);Ox32a=Math.max(document[OxO5d01[6]].scrollLeft,document[OxO5d01[7]].scrollLeft);if(Ox326[OxO5d01[8]]){Ox327=Ox326.getBoundingClientRect()[OxO5d01[9]];Ox328=Ox326.getBoundingClientRect()[OxO5d01[10]];} else {if(document[OxO5d01[11]]){Ox327=document.getBoxObjectFor(Ox326)[OxO5d01[12]]-Ox32a;Ox328=document.getBoxObjectFor(Ox326)[OxO5d01[13]]-Ox329;} ;} ;if(this[OxO5d01[19]]>1){this[OxO5d01[19]]-=0.1;this[OxO5d01[4]][OxO5d01[20]]=Math.ceil(Ox326[OxO5d01[14]]*this[OxO5d01[19]])+OxO5d01[21];this[OxO5d01[4]][OxO5d01[22]]=Math.ceil(Ox326[OxO5d01[15]]*this[OxO5d01[19]])+OxO5d01[21];Ox328=Math.ceil(Ox328+Ox329-(this[OxO5d01[14]]-Ox326[OxO5d01[14]])/2)+OxO5d01[21];;;Ox327=Math.ceil(Ox327+Ox32a-(this[OxO5d01[15]]-Ox326[OxO5d01[15]])/2)+OxO5d01[21];this[OxO5d01[4]][OxO5d01[10]]=Ox328;this[OxO5d01[4]][OxO5d01[9]]=Ox327;this[OxO5d01[23]]=setTimeout(OxO5d01[28]+this[OxO5d01[25]]+OxO5d01[26],0);} else {this[OxO5d01[4]][OxO5d01[29]]=OxO5d01[30];} ;} ;function Ox32e(){var Ox32f=Ox324;if(Ox32f[OxO5d01[31]]==null){document[OxO5d01[7]].appendChild(Ox32f);} ;if((render_spring_image[OxO5d01[27]]!=null)&&(render_spring_image[OxO5d01[27]]!=this)){render_spring_image[OxO5d01[27]][OxO5d01[23]]=setTimeout(OxO5d01[28]+render_spring_image[OxO5d01[27]][OxO5d01[25]]+OxO5d01[26],0);} ;render_spring_image[OxO5d01[27]]=Ox32f;Ox32f[OxO5d01[4]][OxO5d01[29]]=OxO5d01[32];Ox32f.expand();} ;function Ox330(){try{if(window[OxO5d01[33]]){hidetip();} ;this.collapse();} catch(x){} ;} ;Ox324= new Image();Ox324[OxO5d01[34]]=Ox29.getAttribute(OxO5d01[35])||Ox29[OxO5d01[34]];Ox324[OxO5d01[36]]=OxO5d01[37];Ox324[OxO5d01[25]]=OxO5d01[37]+render_spring_image[OxO5d01[2]];Ox324[OxO5d01[23]]=setTimeout(OxO5d01[38],0);Ox324[OxO5d01[19]]=1;Ox324[OxO5d01[5]]=Ox29;Ox324[OxO5d01[39]]=Ox325;Ox324[OxO5d01[40]]=Ox32d;Ox324[OxO5d01[41]]=Ox330;Ox324[OxO5d01[42]]=Ox331;Ox324[OxO5d01[43]]=function (){insert(Ox29.getAttribute(OxO5d01[35]));} ;function Ox331(){var Ox332=Ox29.getAttribute(OxO5d01[44]);showTooltip(Ox332,this);} ;try{Ox29[OxO5d01[42]]=Ox32e;} catch(x){} ;} ;if(document[OxO5d01[11]]!=null){HTMLElement[OxO5d01[46]][OxO5d01[45]]=function (){var Ox333=this[OxO5d01[48]].createEvent(OxO5d01[47]);Ox333.initMouseEvent(OxO5d01[45],true,true,this[OxO5d01[48]].defaultView,1,0,0,0,0,false,false,false,false,0,null);this.dispatchEvent(Ox333);} ;} ;function spring_image_scrcoll(){render_spring_image[OxO5d01[27]]=null;} ;if(window[OxO5d01[49]]){window.addEventListener(OxO5d01[50],spring_image_scrcoll,true);} else {if(window[OxO5d01[51]]){window.attachEvent(OxO5d01[52],spring_image_scrcoll);} ;} ;function spring_expand(Ox9a){var Ox29=document.getElementById(Ox9a);if(Ox29){Ox29.expand();} ;} ;function spring_collapse(Ox9a){var Ox29=document.getElementById(Ox9a);if(Ox29){Ox29.collapse();} ;} ;