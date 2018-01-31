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
	import fl.containers.UILoader;
	import flash.net.URLRequest;
	import flash.sampler.Sample;
	import flash.globalization.NumberFormatter;
	import flash.globalization.LocaleID;
		
	public class NhanhDau extends CasparTemplate{
		
		public var myTotalBar:MovieClip = new totalBar();
				
		private var txtGroup:MovieClip = new MovieClip();
					
		public var title1:TextField = new TextField();
		public var title2:TextField = new TextField();
		public var title3:TextField = new TextField();
		public var title4:TextField = new TextField();
		public var title5:TextField = new TextField();
		public var title6:TextField = new TextField();
		public var title7:TextField = new TextField();
		public var title8:TextField = new TextField();
		public var title9:TextField = new TextField();
		public var title10:TextField = new TextField();
		public var title11:TextField = new TextField();
		public var title12:TextField = new TextField();
		public var title13:TextField = new TextField();
		public var title14:TextField = new TextField();
		public var title15:TextField = new TextField();
		public var title16:TextField = new TextField();
		public var title17:TextField = new TextField();
		public var title18:TextField = new TextField();
		public var title19:TextField = new TextField();
		public var title20:TextField = new TextField();
		public var title21:TextField = new TextField();
		public var title22:TextField = new TextField();
		public var title23:TextField = new TextField();
		public var title24:TextField = new TextField();
		public var title25:TextField = new TextField();
		public var title26:TextField = new TextField();
		public var title27:TextField = new TextField();
		public var title28:TextField = new TextField();
		public var title29:TextField = new TextField();
		public var title30:TextField = new TextField();
		public var title31:TextField = new TextField();
		public var title32:TextField = new TextField();
		public var title33:TextField = new TextField();
		public var title34:TextField = new TextField();
		public var title35:TextField = new TextField();
		public var title36:TextField = new TextField();
							
		private var maskBar:Shape = new Shape();
		private var rectWidth:Number = 900;
		private var rectHeight:Number = 160;
		private var rcolor:Array = new Array();
		private var alphas:Array = new Array();
		private var ratios:Array = new Array();
		
		private var singleTween:Tween = null;
		private var txtTween:Tween = null;
				
		public function NhanhDau() {
			// constructor code
			super();
			
			this.addChild(myTotalBar);
			this.txtGroup.addChild(title1);	
			this.txtGroup.addChild(title2);
			this.txtGroup.addChild(title3);
			this.txtGroup.addChild(title4);
			this.txtGroup.addChild(title5);
			this.txtGroup.addChild(title6);
			this.txtGroup.addChild(title7);
			this.txtGroup.addChild(title8);
			this.txtGroup.addChild(title9);	
			this.txtGroup.addChild(title10);
			this.txtGroup.addChild(title11);
			this.txtGroup.addChild(title12);
			this.txtGroup.addChild(title13);
			this.txtGroup.addChild(title14);
			this.txtGroup.addChild(title15);
			this.txtGroup.addChild(title16);
			this.txtGroup.addChild(title17);
			this.txtGroup.addChild(title18);
			this.txtGroup.addChild(title19);	
			this.txtGroup.addChild(title20);
			this.txtGroup.addChild(title21);
			this.txtGroup.addChild(title22);
			this.txtGroup.addChild(title23);
			this.txtGroup.addChild(title24);
			this.txtGroup.addChild(title25);
			this.txtGroup.addChild(title26);
			this.txtGroup.addChild(title27);
			this.txtGroup.addChild(title28);
			this.txtGroup.addChild(title29);	
			this.txtGroup.addChild(title30);
			this.txtGroup.addChild(title31);
			this.txtGroup.addChild(title32);
			this.txtGroup.addChild(title33);
			this.txtGroup.addChild(title34);
			this.txtGroup.addChild(title35);
			this.txtGroup.addChild(title36);			
			
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
			
			this.myTotalBar.mask = this.maskBar;
			this.txtGroup.visible = false;
			this.myTotalBar.visible = false;			
			
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
			xmlStr +=Add(xmlStr, "title1", title1);
			xmlStr +=Add(xmlStr, "title2", title2);
			xmlStr +=Add(xmlStr, "title3", title3);
			xmlStr +=Add(xmlStr, "title4", title4);
			xmlStr +=Add(xmlStr, "title5", title5);
			xmlStr +=Add(xmlStr, "title6", title6);
			xmlStr +=Add(xmlStr, "title7", title7);
			xmlStr +=Add(xmlStr, "title8", title8);
			xmlStr +=Add(xmlStr, "title9", title9);
			xmlStr +=Add(xmlStr, "title10", title10);
			xmlStr +=Add(xmlStr, "title11", title11);
			xmlStr +=Add(xmlStr, "title12", title12);
			xmlStr +=Add(xmlStr, "title13", title13);
			xmlStr +=Add(xmlStr, "title14", title14);
			xmlStr +=Add(xmlStr, "title15", title15);
			xmlStr +=Add(xmlStr, "title16", title16);
			xmlStr +=Add(xmlStr, "title17", title17);
			xmlStr +=Add(xmlStr, "title18", title18);
			xmlStr +=Add(xmlStr, "title19", title19);
			xmlStr +=Add(xmlStr, "title20", title20);
			xmlStr +=Add(xmlStr, "title21", title21);
			xmlStr +=Add(xmlStr, "title22", title22);
			xmlStr +=Add(xmlStr, "title23", title23);
			xmlStr +=Add(xmlStr, "title24", title24);
			xmlStr +=Add(xmlStr, "title25", title25);
			xmlStr +=Add(xmlStr, "title26", title26);
			xmlStr +=Add(xmlStr, "title27", title27);
			xmlStr +=Add(xmlStr, "title28", title28);
			xmlStr +=Add(xmlStr, "title29", title29);
			xmlStr +=Add(xmlStr, "title30", title30);
			xmlStr +=Add(xmlStr, "title31", title31);
			xmlStr +=Add(xmlStr, "title32", title32);
			xmlStr +=Add(xmlStr, "title33", title33);
			xmlStr +=Add(xmlStr, "title34", title34);
			xmlStr +=Add(xmlStr, "title35", title35);
			xmlStr +=Add(xmlStr, "title36", title36);
			
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
					case "title1".toLowerCase():
						this.title1.text = data.toUpperCase();
						break;
					case "title2".toLowerCase():
						this.title2.text = data.toUpperCase();
						break;
					case "title3".toLowerCase():
						this.title3.text = data.toUpperCase();
						break;
					case "title4".toLowerCase():
						this.title4.text = data.toUpperCase();
						break;
					case "title5".toLowerCase():
						this.title5.text = data.toUpperCase();
						break;
					case "title6".toLowerCase():
						this.title6.text = data.toUpperCase();
						break;
					case "title7".toLowerCase():
						this.title7.text = data.toUpperCase();
						break;
					case "title8".toLowerCase():
						this.title8.text = data.toUpperCase();
						break;
					case "title9".toLowerCase():
						this.title9.text = data.toUpperCase();
						break;
					case "title10".toLowerCase():
						this.title10.text = data.toUpperCase();
						break;
					case "title11".toLowerCase():
						this.title11.text = data.toUpperCase();
						break;
					case "title12".toLowerCase():
						this.title12.text = data.toUpperCase();
						break;
					case "title13".toLowerCase():
						this.title13.text = data.toUpperCase();
						break;
					case "title14".toLowerCase():
						this.title14.text = data.toUpperCase();
						break;
					case "title15".toLowerCase():
						this.title15.text = data.toUpperCase();
						break;
					case "title16".toLowerCase():
						this.title16.text = data.toUpperCase();
						break;
					case "title17".toLowerCase():
						this.title17.text = data.toUpperCase();
						break;
					case "title18".toLowerCase():
						this.title18.text = data.toUpperCase();
						break;
					case "title19".toLowerCase():
						this.title19.text = data.toUpperCase();
						break;
					case "title20".toLowerCase():
						this.title20.text = data.toUpperCase();
						break;
					case "title21".toLowerCase():
						this.title21.text = data.toUpperCase();
						break;
					case "title22".toLowerCase():
						this.title22.text = data.toUpperCase();
						break;
					case "title23".toLowerCase():
						this.title23.text = data.toUpperCase();
						break;
					case "title24".toLowerCase():
						this.title24.text = data.toUpperCase();
						break;
					case "title25".toLowerCase():
						this.title25.text = data.toUpperCase();
						break;
					case "title26".toLowerCase():
						this.title26.text = data.toUpperCase();
						break;
					case "title27".toLowerCase():
						this.title27.text = data.toUpperCase();
						break;
					case "title28".toLowerCase():
						this.title28.text = data.toUpperCase();
						break;
					case "title29".toLowerCase():
						this.title29.text = data.toUpperCase();
						break;
					case "title30".toLowerCase():
						this.title30.text = data.toUpperCase();
						break;
					case "title31".toLowerCase():
						this.title31.text = data.toUpperCase();
						break;
					case "title32".toLowerCase():
						this.title32.text = data.toUpperCase();
						break;
					case "title33".toLowerCase():
						this.title33.text = data.toUpperCase();
						break;
					case "title34".toLowerCase():
						this.title34.text = data.toUpperCase();
						break;
					case "title35".toLowerCase():
						this.title35.text = data.toUpperCase();
						break;
					case "title36".toLowerCase():
						this.title36.text = data.toUpperCase();
						break;					
				}
			}
		}
		private function comeIn():void{
			this.myTotalBar.visible = true;
			this.singleTween = new Tween(myTotalBar, "x", Regular.easeOut, -1500, 960, 0.5, true);
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
			this.singleTween = new Tween(myTotalBar, "y", Regular.easeOut, 540, 1200, 1, true);
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
			
	}
	
}
