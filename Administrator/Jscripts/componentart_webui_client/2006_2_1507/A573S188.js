if(!window.ComponentArt_ItemLook_Loaded){window.ComponentArt_ItemLookCollection=function(qqRc){if(window.ComponentArt_Atlas){ComponentArt.Web.UI.ItemLookCollection.initializeBase(this);this.getDescriptor=function(){return ComponentArt_CreateAtlasTypeDescriptor(this);};};for(var qzba=0;qzba<qqRc.length;qzba++){var qqRb=qqRc[qzba],lookId=qqRb[1];this[lookId]=this[qzba]=qqGp(ComponentArt_ItemLook,qqRb);};this.length=qqRc.length;};window.ComponentArt_ItemLook=function(){if(window.ComponentArt_Atlas){ComponentArt.Web.UI.ItemLook.initializeBase(this);this.getDescriptor=function(){return ComponentArt_CreateAtlasTypeDescriptor(this);};};};ComponentArt_ItemLookCollection.prototype.PublicProperties=[];ComponentArt_ItemLookCollection.prototype.PublicMethods=[['GetProperty',,Object,[['propName',String]]],['SetProperty',,null,[['propName',String],['propValue',Object]]]];window.ComponentArt.Web.UI.ItemLookCollection=ComponentArt_ItemLookCollection;ComponentArt_CreateAtlasAccessors(ComponentArt_ItemLookCollection);if(window.ComponentArt_Atlas){ComponentArt.Web.UI.ItemLookCollection.registerClass('ComponentArt.Web.UI.ItemLookCollection');if(Sys.TypeDescriptor)Sys.TypeDescriptor.addType('componentArtWebUI','itemLookCollection',ComponentArt.Web.UI.ItemLookCollection);};ComponentArt_ItemLookCollection.prototype.GetProperty=function(propName){return this[propName];};ComponentArt_ItemLookCollection.prototype.SetProperty=function(propName,propValue){this[propName]=propValue;};ComponentArt_ItemLook.prototype.PublicProperties=[['ActiveCssClass',String],['ActiveImageUrl',String],['ActiveLeftIconUrl',String],['ActiveRightIconUrl',String],['CssClass',String],['ExpandedCssClass',String],['ExpandedImageUrl',String],['ExpandedLeftIconUrl',String],['ExpandedRightIconUrl',String],['HoverCssClass',String],['HoverImageUrl',String],['HoverLeftIconUrl',String],['HoverRightIconUrl',String],['ImageHeight',Number],['ImageUrl',String],['ImageWidth',Number],['LabelPaddingBottom',Number],['LabelPaddingLeft',Number],['LabelPaddingRight',Number],['LabelPaddingTop',Number],['LeftIconHeight',Number],['LeftIconUrl',String],['LeftIconWidth',Number],['LookId',String],['RightIconHeight',Number],['RightIconUrl',String],['RightIconWidth',Number]];ComponentArt_ItemLook.prototype.PublicMethods=[['ApplyTo',,null,[['destinationLook',ComponentArt_ItemLook]]],['ApplyFrom',,null,[['sourceLook',ComponentArt_ItemLook]]],['CopyTo',,null,[['destinationLook',ComponentArt_ItemLook]]],['CopyFrom',,null,[['sourceLook',ComponentArt_ItemLook]]],['GetProperty',,Object,[['propName',String]]],['IsEmpty',,Boolean],['SetProperty',,null,[['propName',String],['propValue',Object]]]];window.ComponentArt.Web.UI.ItemLook=ComponentArt_ItemLook;ComponentArt_CreateAtlasAccessors(ComponentArt_ItemLook);if(window.ComponentArt_Atlas){ComponentArt.Web.UI.ItemLook.registerClass('ComponentArt.Web.UI.ItemLook');if(Sys.TypeDescriptor)Sys.TypeDescriptor.addType('componentArtWebUI','itemLook',ComponentArt.Web.UI.ItemLook);};ComponentArt_ItemLook.prototype.GetProperty=function(propName){return this[propName];};ComponentArt_ItemLook.prototype.SetProperty=function(propName,propValue){this[propName]=propValue;};ComponentArt_ItemLook.prototype.TransitoryProperties=ComponentArt_ItemLook.TransitoryProperties=[];ComponentArt_ItemLook.prototype.qqGr=ComponentArt_ItemLook.qqGr=['LookId',,'CssClass',,'HoverCssClass',,'ImageHeight',,'ImageWidth',,'LabelPaddingBottom',,'LabelPaddingLeft',,'LabelPaddingRight',,'LabelPaddingTop',,'ActiveCssClass',,'ExpandedCssClass',,'LeftIconUrl',,'HoverLeftIconUrl',,'LeftIconWidth',,'LeftIconHeight',,'ActiveLeftIconUrl',,'ExpandedLeftIconUrl',,'RightIconUrl',,'HoverRightIconUrl',,'RightIconWidth',,'RightIconHeight',,'ActiveRightIconUrl',,'ExpandedRightIconUrl',,'ImageUrl',,'HoverImageUrl',,'ActiveImageUrl',,'ExpandedImageUrl',];ComponentArt_ItemLook.prototype.PropertyList=ComponentArt_ItemLook.PropertyList={'CssClass':0,'HoverCssClass':0,'ImageHeight':0,'ImageWidth':0,'LabelPaddingBottom':0,'LabelPaddingLeft':0,'LabelPaddingRight':0,'LabelPaddingTop':0,'ActiveCssClass':0,'ExpandedCssClass':0,'LeftIconUrl':0,'HoverLeftIconUrl':0,'LeftIconWidth':0,'LeftIconHeight':0,'ActiveLeftIconUrl':0,'ExpandedLeftIconUrl':0,'RightIconUrl':0,'HoverRightIconUrl':0,'RightIconWidth':0,'RightIconHeight':0,'ActiveRightIconUrl':0,'ExpandedRightIconUrl':0,'ImageUrl':0,'HoverImageUrl':0,'ActiveImageUrl':0,'ExpandedImageUrl':0};ComponentArt_ItemLook.prototype.ApplyTo=function(destinationLook){for(var qzba=0;qzba<this.qqGr.length;qzba+=2){var qqGz=this.qqGr[qzba];if(destinationLook[qqGz]==null){destinationLook[qqGz]=this[qqGz];};};};ComponentArt_ItemLook.prototype.ApplyFrom=function(sourceLook){for(var qzba=0;qzba<this.qqGr.length;qzba+=2){var qqGz=this.qqGr[qzba];if(this[qqGz]==null){this[qqGz]=sourceLook[qqGz];};};};ComponentArt_ItemLook.prototype.CopyTo=function(destinationLook){for(var qzba=0;qzba<this.qqGr.length;qzba+=2){var qqGz=this.qqGr[qzba];destinationLook[qqGz]=this[qqGz];};};ComponentArt_ItemLook.prototype.CopyFrom=function(sourceLook){for(var qzba=0;qzba<this.qqGr.length;qzba+=2){var qqGz=this.qqGr[qzba];this[qqGz]=sourceLook[qqGz];};};ComponentArt_ItemLook.prototype.IsEmpty=function(){for(var qzba=0;qzba<this.qqGr.length;qzba+=2){var qqGz=this.qqGr[qzba];if(this[qqGz]!=null){return false;};};return true;};window.ComponentArt_ItemLook_Loaded=true;};
