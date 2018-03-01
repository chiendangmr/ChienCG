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
		
	public class BongDa_DanhSachDuBi extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:UILoader = null;
		private var request:URLRequest = null;
					
		public var doibong:TextField = new TextField();
		public var dubiNumber1:TextField = new TextField();
		public var dubiNumber2:TextField = new TextField();
		public var dubiNumber3:TextField = new TextField();
		public var dubiNumber4:TextField = new TextField();
		public var dubiNumber5:TextField = new TextField();
		public var dubiNumber6:TextField = new TextField();
		public var dubiNumber7:TextField = new TextField();
		public var dubiNumber8:TextField = new TextField();
		public var dubiNumber9:TextField = new TextField();
		public var dubiNumber10:TextField = new TextField();
		public var dubiName1:TextField = new TextField();
		public var dubiName2:TextField = new TextField();
		public var dubiName3:TextField = new TextField();
		public var dubiName4:TextField = new TextField();
		public var dubiName5:TextField = new TextField();
		public var dubiName6:TextField = new TextField();
		public var dubiName7:TextField = new TextField();
		public var dubiName8:TextField = new TextField();
		public var dubiName9:TextField = new TextField();
		public var dubiName10:TextField = new TextField();
				
		public function BongDa_DanhSachDuBi() {
			// constructor code
			super();							
			this.txtGroup.addChild(doibong);	
			this.txtGroup.addChild(dubiNumber1);
			this.txtGroup.addChild(dubiNumber2);
			this.txtGroup.addChild(dubiNumber3);	
			this.txtGroup.addChild(dubiNumber4);
			this.txtGroup.addChild(dubiNumber5);
			this.txtGroup.addChild(dubiNumber6);	
			this.txtGroup.addChild(dubiNumber7);
			this.txtGroup.addChild(dubiNumber8);
			this.txtGroup.addChild(dubiNumber9);	
			this.txtGroup.addChild(dubiNumber10);
			this.txtGroup.addChild(dubiName1);
			this.txtGroup.addChild(dubiName2);	
			this.txtGroup.addChild(dubiName3);
			this.txtGroup.addChild(dubiName4);
			this.txtGroup.addChild(dubiName5);	
			this.txtGroup.addChild(dubiName6);
			this.txtGroup.addChild(dubiName7);
			this.txtGroup.addChild(dubiName8);	
			this.txtGroup.addChild(dubiName9);
			this.txtGroup.addChild(dubiName10);
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
			xmlStr +=Add(xmlStr, "doibong", doibong);
			xmlStr +=Add(xmlStr, "dubiNumber1", dubiNumber1);
			xmlStr +=Add(xmlStr, "dubiNumber2", dubiNumber2);
			xmlStr +=Add(xmlStr, "dubiNumber3", dubiNumber3);
			xmlStr +=Add(xmlStr, "dubiNumber4", dubiNumber4);
			xmlStr +=Add(xmlStr, "dubiNumber5", dubiNumber5);
			xmlStr +=Add(xmlStr, "dubiNumber6", dubiNumber6);
			xmlStr +=Add(xmlStr, "dubiNumber7", dubiNumber7);
			xmlStr +=Add(xmlStr, "dubiNumber8", dubiNumber8);
			xmlStr +=Add(xmlStr, "dubiNumber9", dubiNumber9);
			xmlStr +=Add(xmlStr, "dubiNumber10", dubiNumber10);
			xmlStr +=Add(xmlStr, "dubiName1", dubiName1);
			xmlStr +=Add(xmlStr, "dubiName2", dubiName2);
			xmlStr +=Add(xmlStr, "dubiName3", dubiName3);
			xmlStr +=Add(xmlStr, "dubiName4", dubiName4);
			xmlStr +=Add(xmlStr, "dubiName5", dubiName5);
			xmlStr +=Add(xmlStr, "dubiName6", dubiName6);
			xmlStr +=Add(xmlStr, "dubiName7", dubiName7);
			xmlStr +=Add(xmlStr, "dubiName8", dubiName8);
			xmlStr +=Add(xmlStr, "dubiName9", dubiName9);
			xmlStr +=Add(xmlStr, "dubiName10", dubiName10);
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
					case "doibong".toLowerCase():
						this.doibong.text = data.toUpperCase();
						break;
					case "dubiNumber1".toLowerCase():
						this.dubiNumber1.text = data.toUpperCase();
						break;
					case "dubiNumber2".toLowerCase():
						this.dubiNumber2.text = data.toUpperCase();
						break;
					case "dubiNumber3".toLowerCase():
						this.dubiNumber3.text = data.toUpperCase();
						break;
					case "dubiNumber4".toLowerCase():
						this.dubiNumber4.text = data.toUpperCase();
						break;
					case "dubiNumber5".toLowerCase():
						this.dubiNumber5.text = data.toUpperCase();
						break;
					case "dubiNumber6".toLowerCase():
						this.dubiNumber6.text = data.toUpperCase();
						break;
					case "dubiNumber7".toLowerCase():
						this.dubiNumber7.text = data.toUpperCase();
						break;
					case "dubiNumber8".toLowerCase():
						this.dubiNumber8.text = data.toUpperCase();
						break;
					case "dubiNumber9".toLowerCase():
						this.dubiNumber9.text = data.toUpperCase();
						break;
					case "dubiNumber10".toLowerCase():
						this.dubiNumber10.text = data.toUpperCase();
						break;
					case "dubiName1".toLowerCase():
						this.dubiName1.text = data.toUpperCase();
						break;
					case "dubiName2".toLowerCase():
						this.dubiName2.text = data.toUpperCase();
						break;
					case "dubiName3".toLowerCase():
						this.dubiName3.text = data.toUpperCase();
						break;
					case "dubiName4".toLowerCase():
						this.dubiName4
					case "dubiName5".toLowerCase():
						this.dubiName5.text = data.toUpperCase();
						break;
					case "dubiName6".toLowerCase():
						this.dubiName6.text = data.toUpperCase();
						break;
					case "dubiName7".toLowerCase():
						this.dubiName7.text = data.toUpperCase();
						break;
					case "dubiName8".toLowerCase():
						this.dubiName8.text = data.toUpperCase();
						break;
					case "dubiName9".toLowerCase():
						this.dubiName9.text = data.toUpperCase();
						break;
					case "dubiName10".toLowerCase():
						this.dubiName10.text = data.toUpperCase();
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
