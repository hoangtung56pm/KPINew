if ("\165n\x64efined"==typeof(RadDockNamespace)){RadDockNamespace=new Object(); }RadDockNamespace.i1p= {I1p: 0,o1q: 1,O1q: 2,l1q: 4,i1q: 8,I1q: 6,o1r: 5,O1r: 10,l1r: 9,i1r: 15 } ; RadDockNamespace.m= function (n){if (!n)return; Object.L(n,RadDockNamespace.I1r); var tagName=(document.all)?"\151\x66\162ame": "span"; var frm=document.createElement(tagName); frm=frm.cloneNode( true); frm.src="javascr\x69\x70t:\047\047\x3b"; frm.frameBorder=0; frm.scrolling="no"; frm.style.filter="pr\x6f\x67id:DXI\x6d\x61geTr\x61nsform\x2e\115i\x63\x72oso\x66\164\x2eAlp\x68\141(\x6f\160a\x63ity=0\x29"; frm.style.overflow="\x68\151dde\x6e"; frm.style.display="i\x6e\x6cine"; frm.style.position="\x61bsolu\x74\x65"; frm.style.left=-10000; frm.style.top=-10000; n.Ia=document.body.insertBefore(frm,document.body.firstChild); n.o7=(n.offsetWidth?n.offsetWidth:parseInt(n.style.width)); n.O7=(n.offsetHeight?n.offsetHeight:parseInt(n.style.height)); } ; RadDockNamespace.I1r= {o1s: 20,O1s: 100000,l1s: 20,i1s: 100000,I1s:RadDockNamespace.i1p.i1r,o7: 0,O7: 0,MoveBy:function (iy,Iy){var x=RadDockNamespace.l1h(this.style.left,0); var y=RadDockNamespace.l1h(this.style.top,0); this.MoveTo(x+iy,y+Iy); } ,MoveTo:function (x,y,Ot){x=RadDockNamespace.l1h(x,0); y=RadDockNamespace.l1h(y,0); if (!Ot){ this.style.position="absolu\x74e"; this.Ia.style.left=this.style.left=(x+"px"); this.Ia.style.top=this.style.top=(y+"\x70\x78"); }else {var o1t=this.GetRect(); this.l9(); this.MoveTo(o1t.left,o1t.top); var O1t=new RadEffect.MoveTo( {object: this,Ow:x,lw:y } ); }} ,l1:function (o1i){if (!document.all)return; if ("\x43SS1Co\x6d\x70at"==document.compatMode){var l1t=this.GetRect(); var l1i=l1t.height; var O1i=(l1i-parseInt(o1i.style.height)); if (O1i>0){var i1i=(parseInt(o1i.style.height)-O1i); if (i1i>0)o1i.style.height=i1i+"px"; }}} ,SetSize:function (width,height){width=RadDockNamespace.l1h(width,-1); height=RadDockNamespace.l1h(height,-1); if (width>-1){ this.Ia.style.width=this.style.width=width+"\x70x"; }if (height>-1){ this.Ia.style.height=this.style.height=height+"\x70x"; }RadDockNamespace.l1(this ); RadDockNamespace.l1(this.Ia); } ,i1t:function (offsetLeft,offsetTop,offsetWidth,offsetHeight){var Of=this.GetRect(); var top=Of.top+offsetTop; var left=Of.left+offsetLeft; if (top<0){offsetTop=-Of.top; }if (left<0){offsetLeft=-Of.left; }top=Of.top+offsetTop; left=Of.left+offsetLeft; if (null==offsetWidth)offsetWidth=-offsetLeft; if (null==offsetHeight)offsetHeight=-offsetTop; var width=Of.width+offsetWidth; var height=Of.height+offsetHeight; width=Math.max(this.o1s,width); width=Math.min(this.O1s,width); height=Math.max(this.l1s,height); height=Math.min(this.i1s,height); if (Of.width!=width){ this.MoveBy(offsetLeft,0); this.SetSize(width,null); }if (Of.height!=height){ this.MoveBy(0,offsetTop); this.SetSize(null,height); }} ,i9:function (){var I1t=0; var zIndex=0; var o1u=this.parentNode.childNodes; var node; for (var i=0; i<o1u.length; i++){node=o1u[i]; if (1!=node.nodeType)continue; zIndex=parseInt(node.style.zIndex); if (zIndex>I1t){I1t=zIndex; }} this.style.zIndex=(I1t+2); if (this.Ia){ this.Ia.style.zIndex=this.style.zIndex-1; }if (!document.all){var parentNode=this.parentNode; parentNode.removeChild(this ); parentNode.appendChild(this ); }} ,S:function (dir,O1u,l1u){switch (dir.toLowerCase()){case "n\x2dre\x73\x69ze": this.i1t(0,l1u,null,null); break; case "s\x2d\x72esize": this.i1t(0,0,0,l1u); break; case "\167\x2d\x72esize": this.i1t(O1u,0,null,null); break; case "e-resize": this.i1t(0,0,O1u,0); break; case "ne-resi\x7a\x65": this.i1t(0,l1u,O1u,null); break; case "\x6ew-re\x73\x69ze": this.i1t(O1u,l1u,null,null); break; case "se-res\x69\x7ae": this.i1t(0,0,O1u,l1u); break; case "\x73w-resi\x7a\x65": this.i1t(O1u,0,null,l1u); break; }} ,GetRect:function (n){return RadGetElementRect(n || this ); } ,SetRect:function (I10){ this.MoveTo(I10.left,I10.top); this.SetSize(I10.width,I10.height); } ,I14:function (eventArgs){var x=eventArgs.clientX+RadDockNamespace.ig(); var y=eventArgs.clientY+RadDockNamespace.Ig(); var Of=this.GetRect(); var borderWidth=RadDockNamespace.l1h(this.style.borderWidth,0)+10; var i1u=""; if (((this.I1s&RadDockNamespace.i1p.o1q)>0) && (Of.top<=y) && (y<=(Of.top+borderWidth))){i1u="n"; }else if (((this.I1s&RadDockNamespace.i1p.O1q)>0) && ((Of.bottom-borderWidth)<=y) && (y<=Of.bottom)){i1u="\x73"; }if (((this.I1s&RadDockNamespace.i1p.i1q)>0) && (Of.left<=x) && (x<=(Of.left+borderWidth))){i1u+="\x77"; }else if (((this.I1s&RadDockNamespace.i1p.l1q)>0) && ((Of.right-borderWidth)<=x) && (x<=Of.right)){i1u+="e"; }if (i1u){i1u+="-resize"; }return i1u; } ,IsVisible:function (){return (this.style.display!="\x6eone"); } ,Show:function (show){if (show== false){ this.o7=this.offsetWidth; this.O7=this.offsetHeight; this.I1u=this.style.display; this.Ia.style.display=this.style.display="no\x6e\x65"; }else { this.Ia.style.display=this.style.display=this.I1u?this.I1u: ""; }if (this.I5){ this.I5(); }} ,Hide:function (){ this.Show( false); }} ;
