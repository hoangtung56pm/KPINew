if ("undefin\x65\x64"==typeof(RadDockNamespace)){RadDockNamespace=new Object(); }RadDockNamespace.RadDockingManager= function (O16,l16,i16,I16,o17,O17,Ot,l17,i17,I17,o18){ this.Document=document; this.i12=O17; this.Oz=I17; this.DockingZones=new Array(); this.DockableObjects=new Array(); this.O18=[]; this.l18=[]; this.le=Ot; this.lx=l17; this.ix=i17; this.i18=o18; this.I18(l16); this.o19(i16); this.O19(); this.l19(I16,o17); this.EnableDocking(O16); var I11=this ; var i19= function (){if (I11){I11.O6(); }} ; RadDockNamespace.l2(window,"u\x6eload",i19); };RadDockNamespace.RadDockingManager.prototype.l19= function (I16,o17){var iz=document.getElementById(I16); if (iz){RadDockNamespace.m(iz); if (document.all){iz.style.filter="p\x72\x6fgid:DX\x49\x6dage\x54\x72an\x73\x66orm\x2e\x4dic\x72\x6f\x73oft.A\x6c\x70ha\x28\157\x70acity\x3d25)"; }else {iz.style.setProperty("-moz-opac\x69\x74y","\x30.25",""); }} this.o12=iz; var i13=document.getElementById(o17); if (i13){RadDockNamespace.I19(i13); } this.o13=i13; } ; RadDockNamespace.RadDockingManager.prototype.I18= function (l16){for (var i=0; i<l16.length; i++){ this.RegisterDockingZone(l16[i]); }} ; RadDockNamespace.RadDockingManager.prototype.O19= function (){for (var i=0; i<this.DockingZones.length; i++){ this.DockingZones[i].SaveState(); }};RadDockNamespace.RadDockingManager.prototype.o19= function (i16){for (var i=0; i<i16.length; i++){ this.RegisterDockableObject(i16[i]); }} ; RadDockNamespace.RadDockingManager.prototype.RegisterDockingZone= function (o1a){if (!o1a || !o1a.length)return; var id=o1a[0]; var i8=this.Document.getElementById(id); if (!i8)return; RadDockNamespace.O1a(i8,o1a.slice(1)); i8.i6=this ; var index=this.O18[i8.id]; if (null==index){index=this.DockingZones.length; } this.DockingZones[index]=i8; this.O18[i8.id]=index; } ; RadDockNamespace.RadDockingManager.prototype.RegisterDockableObject= function (M){if (!M || !M.length)return; var id=M[0]; var oj=this.Document.getElementById(id); if (!oj)return; RadDockNamespace.N(oj,M.slice(1)); oj.i6=this ; var index=this.l18[oj.id]; if (null==index){index=this.DockableObjects.length; } this.DockableObjects[index]=oj; this.l18[oj.id]=index; if (this.DockableObjects.length==this.i18){ this.O19(); }} ; RadDockNamespace.RadDockingManager.prototype.EnableDocking= function (O16){ this.O14=O16; if (this.O14){RadDockNamespace.l2(this.Document,"mous\x65m\x6f\x76e",RadDockNamespace.oq); RadDockNamespace.l2(this.Document,"\x6d\x6fusedow\x6e",RadDockNamespace.lr); RadDockNamespace.l2(this.Document,"\155\x6f\x75seup",RadDockNamespace.Ir); RadDockNamespace.l2(this.Document,"ke\x79\x64own",RadDockNamespace.ls); }else {RadDockNamespace.l1a(this.Document,"m\x6f\x75semove",RadDockNamespace.oq); RadDockNamespace.l1a(this.Document,"\x6doused\x6f\x77n",RadDockNamespace.lr); RadDockNamespace.l1a(this.Document,"mouse\x75\x70",RadDockNamespace.Ir); RadDockNamespace.l1a(this.Document,"keydown",RadDockNamespace.ls); }} ; RadDockNamespace.RadDockingManager.prototype.o10= function (oj,eventArgs,i1a){var i8; var I1a; for (var i=0; i<this.DockingZones.length; i++){i8=this.DockingZones[i]; if (i8.HitTest(oj,eventArgs,i1a)){I1a=i8; }}for (var i=0; i<this.DockingZones.length; i++){i8=this.DockingZones[i]; i8.ly(i8==I1a); }return I1a; } ; RadDockNamespace.RadDockingManager.prototype.O6= function (){for (var i=0; i<this.DockableObjects.length; i++){ this.DockableObjects[i].O6(); this.DockableObjects[i]=null; }for (var i=0; i<this.DockingZones.length; i++){ this.DockingZones[i].O6(); this.DockingZones[i]=null; } this.DockableObjects=null; this.DockingZones=null; this.Document=null; this.o12=null; Im=null; oo=null; Oo=null; op=null; } ; RadDockNamespace.RadDockingManager.prototype.SaveState= function (){var iq; for (var i=0; i<this.DockableObjects.length; i++){iq=this.DockableObjects[i]; if (iq && iq.SaveState){iq.SaveState(); }}for (var i=0; i<this.DockingZones.length; i++){iq=this.DockingZones[i]; if (iq && iq.SaveState){iq.SaveState(); }}} ;
