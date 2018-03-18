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
	import flash.net.URLRequest;
	import flash.sampler.Sample;
	import flash.globalization.NumberFormatter;
	import flash.globalization.LocaleID;
		
	public class BongDa_BuGioGocTrai extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
					
		public var bugio:TextField = new TextField();		
				
		var clockTimer:Timer = new Timer(1000, 0);
		var _phut:Number=0;
		var _giay:Number=0;
						
		public function BongDa_BuGioGocTrai() {
			// constructor code
			super();
			
			this.txtGroup.addChild(bugio);			
			this.addChild(txtGroup);			
			
			//clockTimer.addEventListener(TimerEvent.TIMER, onClockTimer);
			//clockTimer.start();			
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
			xmlStr +=Add(xmlStr, "bugio", bugio);	
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
					case "bugio".toLowerCase():							
						this.bugio.text = "+" + data.toUpperCase();
						break;											
				}
			}
		}		
		public override function Play():void{
			gotoAndPlay('start');
		}
		public override function Stop():void{
			gotoAndPlay('stop');
		}
		function onClockTimer(e:TimerEvent):void {
			this.bugio.text = getFormattedTime();
		}
		
		function getFormattedTime():String {			
			_giay++;
			if(_giay==60){
				_phut++;
				_giay=0;
				}			
			if((_phut==45||_phut==90||_phut==105||_phut==120)&&_giay==0){
				_giay=0;
				}
			var minute:String;
			if(_phut < 10) minute = "0" + _phut;
				else minute=String(_phut);
			
			var second:String;
			if(_giay < 10) second = "0" + _giay;
				else second=String(_giay);
			return minute + ":" + second;
		}	
		function parse(str:String):Number
		{
			for(var i = 0; i < str.length; i++)
			{
				var c:String = str.charAt(i);
				if(c != "0") break;
			}

			return Number(str.substr(i));
		}		
		function parseGiay(str:String):Number
		{
			for(var i = 0; i < str.length; i++)
			{
				var c:String = str.charAt(i);
				if(c == ":") break;
			}

			return parse(str.substr(i+1));
		}
		function parsePhut(str:String):Number
		{
			for(var i = 0; i < str.length; i++)
			{
				var c:String = str.charAt(i);
				if(c == ":") break;
			}

			return parse(str.substr(0,i));
		}
	}
	
}
