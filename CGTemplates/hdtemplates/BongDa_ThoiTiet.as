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
		
	public class BongDa_ThoiTiet extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		
		public var txtThoitiet:TextField = new TextField();
		public var nhietdo:TextField = new TextField();
		public var sucgio:TextField = new TextField();
		public var stadium:TextField = new TextField();
		public var doam:TextField = new TextField();
		public var title1:TextField = new TextField();
		public var title2:TextField = new TextField();
		public var title3:TextField = new TextField();
		public var title4:TextField = new TextField();
		public var title5:TextField = new TextField();
		public var title6:TextField = new TextField();
		
		public function BongDa_ThoiTiet() {
			// constructor code
			super();							
			this.txtGroup.addChild(txtThoitiet);	
			this.txtGroup.addChild(nhietdo);
			this.txtGroup.addChild(sucgio);
			this.txtGroup.addChild(stadium);
			this.txtGroup.addChild(doam);
			this.txtGroup.addChild(title1);
			this.txtGroup.addChild(title2);
			this.txtGroup.addChild(title3);
			this.txtGroup.addChild(title4);
			this.txtGroup.addChild(title5);
			this.txtGroup.addChild(title6);
			
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
			xmlStr +=Add(xmlStr, "txtThoitiet", txtThoitiet);
			xmlStr +=Add(xmlStr, "nhietdo", nhietdo);
			xmlStr +=Add(xmlStr, "sucgio", sucgio);
			xmlStr +=Add(xmlStr, "stadium", stadium);	
			xmlStr +=Add(xmlStr, "doam", doam);	
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
					case "txtThoitiet".toLowerCase():
						this.txtThoitiet.text = data;
						break;
					case "nhietdo".toLowerCase():
						this.nhietdo.text = data.toUpperCase();
						break;
					case "sucgio".toLowerCase():
						this.sucgio.text = data.toUpperCase();
						break;	
					case "stadium".toLowerCase():
						this.stadium.text = data;
						break;
					case "doam".toLowerCase():
						this.doam.text = data.toUpperCase();
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
