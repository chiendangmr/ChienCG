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
		
	public class BongDa_TrongTai extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
					
		public var trongtaichinh:TextField = new TextField();
		public var troly1:TextField = new TextField();
		public var troly2:TextField = new TextField();
		public var trongtaiban:TextField = new TextField();
		
		public function BongDa_TrongTai() {
			// constructor code
			super();							
			this.txtGroup.addChild(trongtaichinh);	
			this.txtGroup.addChild(troly1);
			this.txtGroup.addChild(troly2);
			this.txtGroup.addChild(trongtaiban);
			
			this.addChild(txtGroup);
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
			xmlStr +=Add(xmlStr, "trongtaichinh", trongtaichinh);
			xmlStr +=Add(xmlStr, "troly1", troly1);
			xmlStr +=Add(xmlStr, "troly2", troly2);
			xmlStr +=Add(xmlStr, "trongtaiban", trongtaiban);				
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
					case "trongtaichinh".toLowerCase():
						this.trongtaichinh.text = data.toUpperCase();
						break;
					case "troly1".toLowerCase():
						this.troly1.text = data.toUpperCase();
						break;
					case "troly2".toLowerCase():
						this.troly2.text = data.toUpperCase();
						break;		
					case "trongtaiban".toLowerCase():
						this.trongtaiban.text = data.toUpperCase();
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
	}
	
}
