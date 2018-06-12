package  {
	
	import flash.display.MovieClip;
	import se.svt.caspar.template.CasparTemplate;
	import flash.text.TextField;
	import flash.text.TextFormat;
	import flash.text.Font;
	import flash.text.TextFieldType;
	import fl.transitions.Tween;
	import fl.transitions.easing.*;
	import flash.display.Shape;
	import flash.geom.Matrix;
	import flash.display.GradientType;
	import fl.transitions.TweenEvent;
	import flash.events.Event;
	import flash.text.TextFormatAlign;
	import flash.filters.*;
	import flash.external.ExternalInterface;
	import flash.utils.Timer;
	import flash.events.TimerEvent;
	import flash.display.Loader;
	import flash.events.IOErrorEvent;
	import flash.display.DisplayObject;
	import fl.containers.UILoader;
	import flash.net.URLRequest;
	import flash.sampler.Sample;
	import flash.globalization.NumberFormatter;
	import flash.globalization.LocaleID;
		
	public class BongDa_Penalty extends CasparTemplate{
		
		public var myBar:MovieClip = new bar();
				
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:MovieClip;
		public var icon2:MovieClip;
		
		public var iconPenXChu1:MovieClip;
		public var iconPenXChu2:MovieClip;
		public var iconPenXChu3:MovieClip;
		public var iconPenXChu4:MovieClip;
		public var iconPenXChu5:MovieClip;
		
		public var iconPenOChu1:MovieClip;
		public var iconPenOChu2:MovieClip;
		public var iconPenOChu3:MovieClip;
		public var iconPenOChu4:MovieClip;
		public var iconPenOChu5:MovieClip;
		
		public var iconPenXKhach1:MovieClip;
		public var iconPenXKhach2:MovieClip;
		public var iconPenXKhach3:MovieClip;
		public var iconPenXKhach4:MovieClip;
		public var iconPenXKhach5:MovieClip;
		
		public var iconPenOKhach1:MovieClip;
		public var iconPenOKhach2:MovieClip;
		public var iconPenOKhach3:MovieClip;
		public var iconPenOKhach4:MovieClip;
		public var iconPenOKhach5:MovieClip;	
					
		public var doiChu:TextField = new TextField();
		public var doiKhach:TextField = new TextField();
		public var tyso:TextField = new TextField();
		public var tysoPen:TextField = new TextField();		
							
		private var maskBar:Shape = new Shape();
		private var rectWidth:Number = 900;
		private var rectHeight:Number = 160;
		private var rcolor:Array = new Array();
		private var alphas:Array = new Array();
		private var ratios:Array = new Array();
		
		private var singleTween:Tween = null;
		private var txtTween:Tween = null;
				
		public function BongDa_Penalty() {
			// constructor code
			super();
			
			this.addChild(myBar);
			this.addChild(doiChu);
			this.addChild(doiKhach);					
			this.addChild(tyso);
			this.addChild(tysoPen);			
					
			this.addChild(iconPenXChu1);	
			this.addChild(iconPenXChu2);
			this.addChild(iconPenXChu3);
			this.addChild(iconPenXChu4);
			this.addChild(iconPenXChu5);
			
			this.addChild(iconPenOChu1);	
			this.addChild(iconPenOChu2);
			this.addChild(iconPenOChu3);
			this.addChild(iconPenOChu4);
			this.addChild(iconPenOChu5);
			
			this.addChild(iconPenXKhach1);	
			this.addChild(iconPenXKhach2);
			this.addChild(iconPenXKhach3);
			this.addChild(iconPenXKhach4);
			this.addChild(iconPenXKhach5);
			
			this.addChild(iconPenOKhach1);	
			this.addChild(iconPenOKhach2);
			this.addChild(iconPenOKhach3);
			this.addChild(iconPenOKhach4);
			this.addChild(iconPenOKhach5);
			
			this.txtGroup.addChild(iconPenXChu1);	
			this.txtGroup.addChild(iconPenXChu2);
			this.txtGroup.addChild(iconPenXChu3);
			this.txtGroup.addChild(iconPenXChu4);
			this.txtGroup.addChild(iconPenXChu5);
			
			this.txtGroup.addChild(iconPenOChu1);	
			this.txtGroup.addChild(iconPenOChu2);	
			this.txtGroup.addChild(iconPenOChu3);
			this.txtGroup.addChild(iconPenOChu4);
			this.txtGroup.addChild(iconPenOChu5);
			
			this.txtGroup.addChild(iconPenXKhach1);	
			this.txtGroup.addChild(iconPenXKhach2);
			this.txtGroup.addChild(iconPenXKhach3);
			this.txtGroup.addChild(iconPenXKhach4);
			this.txtGroup.addChild(iconPenXKhach5);
			
			this.txtGroup.addChild(iconPenOKhach1);	
			this.txtGroup.addChild(iconPenOKhach2);
			this.txtGroup.addChild(iconPenOKhach3);
			this.txtGroup.addChild(iconPenOKhach4);
			this.txtGroup.addChild(iconPenOKhach5);
			
			this.txtGroup.addChild(doiChu);
			this.txtGroup.addChild(doiKhach);
			this.txtGroup.addChild(tyso);
			this.txtGroup.addChild(tysoPen);	
			this.txtGroup.addChild(icon1);
			this.txtGroup.addChild(icon2);
			this.addChild(txtGroup);
			this.addChild(txtGroup);
			
			this.addChild(maskBar);
			this.maskBar.x = 150;
			this.maskBar.y = 50;
			this.alphas = [1, 1];
			this.ratios = [0, 255];
			this.rcolor = [0xFFFFFF, 0xFFFFFF];
			this.rectHeight = 1000;
			this.rectWidth = 1700;
			this.drawShapes(maskBar, alphas, ratios, rcolor, toRad(-90, -95), rectWidth, rectHeight);
			
			this.myBar.mask = this.maskBar;
			this.txtGroup.visible = false;			
			this.myBar.visible = false;		
			
			this.iconPenXChu1.visible=false;	
			this.iconPenXChu2.visible=false;
			this.iconPenXChu3.visible=false;
			this.iconPenXChu4.visible=false;
			this.iconPenXChu5.visible=false;
			
			this.iconPenOChu1.visible=false;	
			this.iconPenOChu2.visible=false;
			this.iconPenOChu3.visible=false;
			this.iconPenOChu4.visible=false;
			this.iconPenOChu5.visible=false;
			
			this.iconPenXKhach1.visible=false;
			this.iconPenXKhach2.visible=false;
			this.iconPenXKhach3.visible=false;
			this.iconPenXKhach4.visible=false;
			this.iconPenXKhach5.visible=false;
			
			this.iconPenOKhach1.visible=false;
			this.iconPenOKhach2.visible=false;
			this.iconPenOKhach3.visible=false;
			this.iconPenOKhach4.visible=false;
			this.iconPenOKhach5.visible=false;
			
			ExternalInterface.addCallback("UpdateData", UpdateData);
			ExternalInterface.addCallback("GetProperties", GetProperties);			
		}		
		
		private function Add(xmlStr:String, str:String, txt:TextField){
			xmlStr='<'+ str + ' id="'+ str + '"><data value="' + txt.text + '"/></' + str +'>';
			return xmlStr;
		}
		function GetProperties()
		{
			var xmlStr:String = "<Track_Property>";
			xmlStr +=Add(xmlStr, "doiChu", doiChu);
			xmlStr +=Add(xmlStr, "doiKhach", doiKhach);
			xmlStr +=Add(xmlStr, "tyso", tyso);
			xmlStr +=Add(xmlStr, "tysoPen", tysoPen);
			xmlStr += "</Track_Property>";
			
			ExternalInterface.call("Properties", xmlStr);
			return xmlStr;
		}
		function UpdateData(str:String)
		{
			var xml:XML = new XML(str);
			this.SetData(xml);
		}
		private var nf:NumberFormatter = new NumberFormatter("en-US"); 
		override public function SetData(xml:XML):void{
			for each (var element:XML in xml.children())
			{
				var property:String = element.@id;
				var data:String = element.data.@value;
				switch(property.toLowerCase())
				{						
					case "doiChu".toLowerCase():
						this.doiChu.text = data.toUpperCase();
						break;	
					case "doiKhach".toLowerCase():
						this.doiKhach.text = data.toUpperCase();
						break;
					case "tyso".toLowerCase():
						this.tyso.text = data.toUpperCase();
						break;
					case "tysoPen".toLowerCase():
						this.tysoPen.text = data.toUpperCase();
						break;	
					
					case "kqPenChu1".toLowerCase():
						if(data=="True")
						{
							this.iconPenOChu1.visible = true;
							this.iconPenXChu1.visible = false;
						}
						else if(data=="False"){
							this.iconPenOChu1.visible = false;
							this.iconPenXChu1.visible = true;
						}else{
							this.iconPenOChu1.visible = false;
							this.iconPenXChu1.visible = false;
						}
						break;
					case "kqPenChu2".toLowerCase():
						if(data=="True")
						{
							this.iconPenOChu2.visible = true;
							this.iconPenXChu2.visible = false;
						}
						else if(data=="False"){
							this.iconPenOChu2.visible = false;
							this.iconPenXChu2.visible = true;
						}else{
							this.iconPenOChu2.visible = false;
							this.iconPenXChu2.visible = false;
						}
						break;		
					case "kqPenChu3".toLowerCase():
						if(data=="True")
						{
							this.iconPenOChu3.visible = true;
							this.iconPenXChu3.visible = false;
						}
						else if(data=="False"){
							this.iconPenOChu3.visible = false;
							this.iconPenXChu3.visible = true;
						}else{
							this.iconPenOChu3.visible = false;
							this.iconPenXChu3.visible = false;
						}
						break;
					case "kqPenChu4".toLowerCase():
						if(data=="True")
						{
							this.iconPenOChu4.visible = true;
							this.iconPenXChu4.visible = false;
						}
						else if(data=="False"){
							this.iconPenOChu4.visible = false;
							this.iconPenXChu4.visible = true;
						}else{
							this.iconPenOChu4.visible = false;
							this.iconPenXChu4.visible = false;
						}
						break;
					case "kqPenChu5".toLowerCase():
						if(data=="True")
						{
							this.iconPenOChu5.visible = true;
							this.iconPenXChu5.visible = false;
						}
						else if(data=="False"){
							this.iconPenOChu5.visible = false;
							this.iconPenXChu5.visible = true;
						}else{
							this.iconPenOChu5.visible = false;
							this.iconPenXChu5.visible = false;
						}
						break;
							
					case "kqPenKhach1".toLowerCase():
						if(data=="True")
						{
							this.iconPenOKhach1.visible = true;
							this.iconPenXKhach1.visible = false;
						}
						else if(data=="False"){
							this.iconPenOKhach1.visible = false;
							this.iconPenXKhach1.visible = true;
						}else{
							this.iconPenOKhach1.visible = false;
							this.iconPenXKhach1.visible = false;
						}
						break;
					case "kqPenKhach2".toLowerCase():
						if(data=="True")
						{
							this.iconPenOKhach2.visible = true;
							this.iconPenXKhach2.visible = false;
						}
						else if(data=="False"){
							this.iconPenOKhach2.visible = false;
							this.iconPenXKhach2.visible = true;
						}else{
							this.iconPenOKhach2.visible = false;
							this.iconPenXKhach2.visible = false;
						}
						break;		
					case "kqPenKhach3".toLowerCase():
						if(data=="True")
						{
							this.iconPenOKhach3.visible = true;
							this.iconPenXKhach3.visible = false;
						}
						else if(data=="False"){
							this.iconPenOKhach3.visible = false;
							this.iconPenXKhach3.visible = true;
						}else{
							this.iconPenOKhach3.visible = false;
							this.iconPenXKhach3.visible = false;
						}
						break;
					case "kqPenKhach4".toLowerCase():
						if(data=="True")
						{
							this.iconPenOKhach4.visible = true;
							this.iconPenXKhach4.visible = false;
						}
						else if(data=="False"){
							this.iconPenOKhach4.visible = false;
							this.iconPenXKhach4.visible = true;
						}else{
							this.iconPenOKhach4.visible = false;
							this.iconPenXKhach4.visible = false;
						}
						break;
					case "kqPenKhach5".toLowerCase():
						if(data=="True")
						{
							this.iconPenOKhach5.visible = true;
							this.iconPenXKhach5.visible = false;
						}
						else if(data=="False"){
							this.iconPenOKhach5.visible = false;
							this.iconPenXKhach5.visible = true;
						}else{
							this.iconPenOKhach5.visible = false;
							this.iconPenXKhach5.visible = false;
						}
						break;
							
					case "icon1".toLowerCase():						
						var file:Loader = new Loader();
						file.contentLoaderInfo.addEventListener(Event.COMPLETE, onOpenImageCompleted);
						file.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onOpenImageError);
						file.load(new URLRequest(data));
						break;
					case "icon2".toLowerCase():						
						var file1:Loader = new Loader();
						file1.contentLoaderInfo.addEventListener(Event.COMPLETE, onOpenImageCompleted2);
						file1.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onOpenImageError2);
						file1.load(new URLRequest(data));
						break;
				}
			}
		}
		private function comeIn():void{
			this.myBar.visible = true;
			this.singleTween = new Tween(myBar, "x", Regular.easeOut, -1500, 213, 0.5, true);
			this.singleTween.addEventListener(TweenEvent.MOTION_FINISH, comeInTxt);
		}
		private function comeInTxt(e:Event):void{
			this.txtGroup.visible = true;
			this.txtTween = new Tween(txtGroup, "alpha", Strong.easeIn, 0, 1, 0.1, true);
		}
		private function comeOut(){
			this.txtTween = new Tween(txtGroup, "alpha", Strong.easeIn, 1, 0, 0.1, true);
			this.txtTween.addEventListener(TweenEvent.MOTION_FINISH, comeOutBar);
		}
		private function comeOutBar(e:Event):void{
			this.singleTween = new Tween(myBar, "y", Regular.easeOut, 432, 1200, 1, true);
		}
		public override function Play():void{
			comeIn();
		}
		public override function Stop():void{
			comeOut();
		}
		private function drawShapes(mrect:Shape, alphas:Array, ratios:Array, colors:Array, r:Number, rectWidth:Number, rectHeight:Number):void {
			var mat:Matrix;
			mat=new Matrix();
			mat.createGradientBox(rectWidth,rectHeight,r);
			mrect.graphics.lineStyle();
			mrect.graphics.beginGradientFill(GradientType.LINEAR,colors,alphas,ratios,mat);
			mrect.graphics.drawRect(0,0,rectWidth,rectHeight);
			mrect.graphics.endFill();
		}
		private function toRad(a:Number, b:Number):Number {
			return a*Math.PI/b;
		}	
		
		private function onOpenImageError(e:IOErrorEvent)
		{
			while(this.icon1.numChildren > 0)
				this.icon1.removeChildAt(0);
		}
		
		private function onOpenImageCompleted(e:Event)
		{
			var bmp:DisplayObject = e.currentTarget.content as DisplayObject;	
			bmp.width=116;
			bmp.height=118;
			this.icon1.addChild(bmp);
		}
		private function onOpenImageError2(e:IOErrorEvent)
		{
			while(this.icon2.numChildren > 0)
				this.icon2.removeChildAt(0);
		}
		
		private function onOpenImageCompleted2(e:Event)
		{
			var bmp:DisplayObject = e.currentTarget.content as DisplayObject;	
			bmp.width=116;
			bmp.height=118;
			this.icon2.addChild(bmp);
		}
			
	}
	
}
