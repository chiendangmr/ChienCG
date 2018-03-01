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
		
	public class BongDa_DanhSachChinhThuc extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:UILoader = null;
		private var request:URLRequest = null;
					
		public var hlv:TextField = new TextField();
		public var doibong:TextField = new TextField();
		public var chinhthucNumber1:TextField = new TextField();
		public var chinhthucNumber2:TextField = new TextField();
		public var chinhthucNumber3:TextField = new TextField();
		public var chinhthucNumber4:TextField = new TextField();
		public var chinhthucNumber5:TextField = new TextField();
		public var chinhthucNumber6:TextField = new TextField();
		public var chinhthucNumber7:TextField = new TextField();
		public var chinhthucNumber8:TextField = new TextField();
		public var chinhthucNumber9:TextField = new TextField();
		public var chinhthucNumber10:TextField = new TextField();
		public var chinhthucNumber11:TextField = new TextField();
		public var chinhthucName1:TextField = new TextField();
		public var chinhthucName2:TextField = new TextField();
		public var chinhthucName3:TextField = new TextField();
		public var chinhthucName4:TextField = new TextField();
		public var chinhthucName5:TextField = new TextField();
		public var chinhthucName6:TextField = new TextField();
		public var chinhthucName7:TextField = new TextField();
		public var chinhthucName8:TextField = new TextField();
		public var chinhthucName9:TextField = new TextField();
		public var chinhthucName10:TextField = new TextField();
		public var chinhthucName11:TextField = new TextField();
		
		public function BongDa_DanhSachChinhThuc() {
			// constructor code
			super();							
			this.txtGroup.addChild(hlv);	
			this.txtGroup.addChild(doibong);
			this.txtGroup.addChild(chinhthucNumber1);
			this.txtGroup.addChild(chinhthucNumber2);	
			this.txtGroup.addChild(chinhthucNumber3);
			this.txtGroup.addChild(chinhthucNumber4);
			this.txtGroup.addChild(chinhthucNumber5);	
			this.txtGroup.addChild(chinhthucNumber6);
			this.txtGroup.addChild(chinhthucNumber7);
			this.txtGroup.addChild(chinhthucNumber8);	
			this.txtGroup.addChild(chinhthucNumber9);
			this.txtGroup.addChild(chinhthucNumber10);
			this.txtGroup.addChild(chinhthucNumber11);	
			this.txtGroup.addChild(chinhthucName1);
			this.txtGroup.addChild(chinhthucName2);
			this.txtGroup.addChild(chinhthucName3);	
			this.txtGroup.addChild(chinhthucName4);
			this.txtGroup.addChild(chinhthucName5);
			this.txtGroup.addChild(chinhthucName6);	
			this.txtGroup.addChild(chinhthucName7);
			this.txtGroup.addChild(chinhthucName8);
			this.txtGroup.addChild(chinhthucName9);	
			this.txtGroup.addChild(chinhthucName10);
			this.txtGroup.addChild(chinhthucName11);
			this.txtGroup.addChild(icon1);
			
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
			xmlStr +=Add(xmlStr, "hlv", hlv);
			xmlStr +=Add(xmlStr, "doibong", doibong);
			xmlStr +=Add(xmlStr, "chinhthucNumber1", chinhthucNumber1);
			xmlStr +=Add(xmlStr, "chinhthucNumber2", chinhthucNumber2);
			xmlStr +=Add(xmlStr, "chinhthucNumber3", chinhthucNumber3);
			xmlStr +=Add(xmlStr, "chinhthucNumber4", chinhthucNumber4);
			xmlStr +=Add(xmlStr, "chinhthucNumber5", chinhthucNumber5);
			xmlStr +=Add(xmlStr, "chinhthucNumber6", chinhthucNumber6);
			xmlStr +=Add(xmlStr, "chinhthucNumber7", chinhthucNumber7);
			xmlStr +=Add(xmlStr, "chinhthucNumber8", chinhthucNumber8);
			xmlStr +=Add(xmlStr, "chinhthucNumber9", chinhthucNumber9);
			xmlStr +=Add(xmlStr, "chinhthucNumber10", chinhthucNumber10);
			xmlStr +=Add(xmlStr, "chinhthucNumber11", chinhthucNumber11);
			xmlStr +=Add(xmlStr, "chinhthucName1", chinhthucName1);
			xmlStr +=Add(xmlStr, "chinhthucName2", chinhthucName2);
			xmlStr +=Add(xmlStr, "chinhthucName3", chinhthucName3);
			xmlStr +=Add(xmlStr, "chinhthucName4", chinhthucName4);
			xmlStr +=Add(xmlStr, "chinhthucName5", chinhthucName5);
			xmlStr +=Add(xmlStr, "chinhthucName6", chinhthucName6);
			xmlStr +=Add(xmlStr, "chinhthucName7", chinhthucName7);
			xmlStr +=Add(xmlStr, "chinhthucName8", chinhthucName8);
			xmlStr +=Add(xmlStr, "chinhthucName9", chinhthucName9);
			xmlStr +=Add(xmlStr, "chinhthucName10", chinhthucName10);
			xmlStr +=Add(xmlStr, "chinhthucName11", chinhthucName11);
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
					case "hlv".toLowerCase():
						this.hlv.text = data.toUpperCase();
						break;
					case "doibong".toLowerCase():
						this.doibong.text = data.toUpperCase();
						break;
					case "chinhthucNumber1".toLowerCase():
						this.chinhthucNumber1.text = data.toUpperCase();
						break;
					case "chinhthucNumber2".toLowerCase():
						this.chinhthucNumber2.text = data.toUpperCase();
						break;
					case "chinhthucNumber3".toLowerCase():
						this.chinhthucNumber3.text = data.toUpperCase();
						break;
					case "chinhthucNumber4".toLowerCase():
						this.chinhthucNumber4.text = data.toUpperCase();
						break;
					case "chinhthucNumber5".toLowerCase():
						this.chinhthucNumber5.text = data.toUpperCase();
						break;
					case "chinhthucNumber6".toLowerCase():
						this.chinhthucNumber6.text = data.toUpperCase();
						break;
					case "chinhthucNumber7".toLowerCase():
						this.chinhthucNumber7.text = data.toUpperCase();
						break;
					case "chinhthucNumber8".toLowerCase():
						this.chinhthucNumber8.text = data.toUpperCase();
						break;
					case "chinhthucNumber9".toLowerCase():
						this.chinhthucNumber9.text = data.toUpperCase();
						break;
					case "chinhthucNumber10".toLowerCase():
						this.chinhthucNumber10.text = data.toUpperCase();
						break;
					case "chinhthucNumber11".toLowerCase():
						this.chinhthucNumber11.text = data.toUpperCase();
						break;
					case "chinhthucName1".toLowerCase():
						this.chinhthucName1.text = data.toUpperCase();
						break;
					case "chinhthucName2".toLowerCase():
						this.chinhthucName2
					case "chinhthucName3".toLowerCase():
						this.chinhthucName3.text = data.toUpperCase();
						break;
					case "chinhthucName4".toLowerCase():
						this.chinhthucName4.text = data.toUpperCase();
						break;
					case "chinhthucName5".toLowerCase():
						this.chinhthucName5.text = data.toUpperCase();
						break;
					case "chinhthucName6".toLowerCase():
						this.chinhthucName6.text = data.toUpperCase();
						break;
					case "chinhthucName7".toLowerCase():
						this.chinhthucName7.text = data.toUpperCase();
						break;
					case "chinhthucName8".toLowerCase():
						this.chinhthucName8.text = data.toUpperCase();
						break;
					case "chinhthucName9".toLowerCase():
						this.chinhthucName9.text = data.toUpperCase();
						break;
					case "chinhthucName10".toLowerCase():
						this.chinhthucName10.text = data.toUpperCase();
						break;
					case "chinhthucName11".toLowerCase():
						this.chinhthucName11.text = data.toUpperCase();
						break;
					case "icon1".toLowerCase():						
						request = new URLRequest(data);
						this.icon1.load(request);
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
