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
		
	public class BarTySoSet2_GiaoBong2 extends CasparTemplate{
		
		public var myTotalBar:MovieClip = new totalBar();
				
		private var txtGroup:MovieClip = new MovieClip();
					
		public var title1:TextField = new TextField();
		public var title2:TextField = new TextField();
		public var title3:TextField = new TextField();
		public var title4:TextField = new TextField();
		public var title5:TextField = new TextField();
		public var title6:TextField = new TextField();
		public var player1:TextField = new TextField();		
		public var player2:TextField = new TextField();
							
		private var maskBar:Shape = new Shape();
		private var rectWidth:Number = 900;
		private var rectHeight:Number = 160;
		private var rcolor:Array = new Array();
		private var alphas:Array = new Array();
		private var ratios:Array = new Array();
		
		private var singleTween:Tween = null;
		private var txtTween:Tween = null;
				
		public function BarTySoSet2_GiaoBong2() {
			// constructor code
			super();
			
			this.addChild(myTotalBar);
			this.txtGroup.addChild(title1);	
			this.txtGroup.addChild(title2);
			this.txtGroup.addChild(title3);
			this.txtGroup.addChild(title4);
			this.txtGroup.addChild(title5);
			this.txtGroup.addChild(title6);
			this.txtGroup.addChild(player1);		
			this.txtGroup.addChild(player2);							
			
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
			xmlStr +=Add(xmlStr, "player1", player1);	
			xmlStr +=Add(xmlStr, "player2", player2);
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
					case "player1".toLowerCase():
						this.player1.text = data.toUpperCase();
						break;
					case "player2".toLowerCase():
						this.player2.text = data.toUpperCase();
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
