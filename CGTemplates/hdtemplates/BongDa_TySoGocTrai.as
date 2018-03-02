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
		
	public class BongDa_TySoGocTrai extends CasparTemplate{
		
		public var myTotalBar:MovieClip = new bar();
				
		private var txtGroup:MovieClip = new MovieClip();
					
		public var dongho:TextField = new TextField();
		public var shortNameChu:TextField = new TextField();
		public var tyso:TextField = new TextField();
		public var shortNameKhach:TextField = new TextField();			
				
		private var maskBar:Shape = new Shape();
		private var rectWidth:Number = 900;
		private var rectHeight:Number = 160;
		private var rcolor:Array = new Array();
		private var alphas:Array = new Array();
		private var ratios:Array = new Array();
		
		private var singleTween:Tween = null;
		private var txtTween:Tween = null;
				
		var clockTimer:Timer = new Timer(1000, 0);
						
		public function BongDa_TySoGocTrai() {
			// constructor code
			super();
			
			this.addChild(myTotalBar);			
			this.txtGroup.addChild(tyso);	
			this.txtGroup.addChild(dongho);
			this.txtGroup.addChild(shortNameChu);	
			this.txtGroup.addChild(shortNameKhach);			
			
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
			
			clockTimer.addEventListener(TimerEvent.TIMER, onClockTimer);
						
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
			xmlStr +=Add(xmlStr, "tyso", tyso);			
			xmlStr +=Add(xmlStr, "dongho", dongho);	
			xmlStr +=Add(xmlStr, "shortNameChu", shortNameChu);
			xmlStr +=Add(xmlStr, "shortNameKhach", shortNameKhach);			
			xmlStr += "</Track_Property>";
			
			ExternalInterface.call("Properties", xmlStr);
			return xmlStr;
		}
		function UpdateData(str:String)
		{
			var xml:XML = new XML(str);
			this.SetData(xml);
		}
		
		override public function SetData(xml:XML):void{
			for each (var element:XML in xml.children())
			{
				var property:String = element.@id;
				var data:String = element.data.@value;
				switch(property.toLowerCase())
				{					
					case "tyso".toLowerCase():
						this.tyso.text = data.toUpperCase();
						break;
					case "dongho".toLowerCase():						
						this.dongho.text = data.toUpperCase();
						clockTimer.start();
						break;				
					case "shortNameChu".toLowerCase():
						this.shortNameChu.text = data;
						break;
					case "shortNameKhach".toLowerCase():
						this.shortNameKhach.text = data;
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
		function onClockTimer(e:TimerEvent):void {
			this.dongho.text = getFormattedTime();
		}
		
		function getFormattedTime():String {
			var now:Date = new Date();
			var hrs:String = String(now.getHours());
			if (hrs.length < 2) {
				hrs = "0" + hrs;
			}
			var mins:String = String(now.getMinutes());
			if (mins.length < 2) {
				mins = "0" + mins;
			}
			return hrs + ":" + mins;
		}	
	}
	
}
