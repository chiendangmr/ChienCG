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
	import flash.net.URLRequest;
	import flash.sampler.Sample;
	import flash.globalization.NumberFormatter;
	import flash.globalization.LocaleID;
		
	public class BongDa_DanhSachCauThu extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:MovieClip;		
					
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
		
		public var dubiNumber1:TextField = new TextField();
		public var dubiNumber2:TextField = new TextField();
		public var dubiNumber3:TextField = new TextField();
		public var dubiNumber4:TextField = new TextField();
		public var dubiNumber5:TextField = new TextField();
		public var dubiNumber6:TextField = new TextField();
		public var dubiNumber7:TextField = new TextField();
		public var dubiNumber8:TextField = new TextField();
		public var dubiNumber9:TextField = new TextField();
		public var dubiName1:TextField = new TextField();
		public var dubiName2:TextField = new TextField();
		public var dubiName3:TextField = new TextField();
		public var dubiName4:TextField = new TextField();
		public var dubiName5:TextField = new TextField();
		public var dubiName6:TextField = new TextField();
		public var dubiName7:TextField = new TextField();
		public var dubiName8:TextField = new TextField();
		public var dubiName9:TextField = new TextField();
		
		public function BongDa_DanhSachCauThu() {
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
			this.txtGroup.addChild(dubiNumber1);
			this.txtGroup.addChild(dubiNumber2);
			this.txtGroup.addChild(dubiNumber3);	
			this.txtGroup.addChild(dubiNumber4);
			this.txtGroup.addChild(dubiNumber5);
			this.txtGroup.addChild(dubiNumber6);	
			this.txtGroup.addChild(dubiNumber7);
			this.txtGroup.addChild(dubiNumber8);
			this.txtGroup.addChild(dubiNumber9);	
			this.txtGroup.addChild(dubiName1);
			this.txtGroup.addChild(dubiName2);	
			this.txtGroup.addChild(dubiName3);
			this.txtGroup.addChild(dubiName4);
			this.txtGroup.addChild(dubiName5);	
			this.txtGroup.addChild(dubiName6);
			this.txtGroup.addChild(dubiName7);
			this.txtGroup.addChild(dubiName8);	
			this.txtGroup.addChild(dubiName9);
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
			xmlStr +=Add(xmlStr, "dubiNumber1", dubiNumber1);
			xmlStr +=Add(xmlStr, "dubiNumber2", dubiNumber2);
			xmlStr +=Add(xmlStr, "dubiNumber3", dubiNumber3);
			xmlStr +=Add(xmlStr, "dubiNumber4", dubiNumber4);
			xmlStr +=Add(xmlStr, "dubiNumber5", dubiNumber5);
			xmlStr +=Add(xmlStr, "dubiNumber6", dubiNumber6);
			xmlStr +=Add(xmlStr, "dubiNumber7", dubiNumber7);
			xmlStr +=Add(xmlStr, "dubiNumber8", dubiNumber8);
			xmlStr +=Add(xmlStr, "dubiNumber9", dubiNumber9);
			xmlStr +=Add(xmlStr, "dubiName1", dubiName1);
			xmlStr +=Add(xmlStr, "dubiName2", dubiName2);
			xmlStr +=Add(xmlStr, "dubiName3", dubiName3);
			xmlStr +=Add(xmlStr, "dubiName4", dubiName4);
			xmlStr +=Add(xmlStr, "dubiName5", dubiName5);
			xmlStr +=Add(xmlStr, "dubiName6", dubiName6);
			xmlStr +=Add(xmlStr, "dubiName7", dubiName7);
			xmlStr +=Add(xmlStr, "dubiName8", dubiName8);
			xmlStr +=Add(xmlStr, "dubiName9", dubiName9);
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
					case "icon1".toLowerCase():						
						var file:Loader = new Loader();
						file.contentLoaderInfo.addEventListener(Event.COMPLETE, onOpenImageCompleted);
						file.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onOpenImageError);
						file.load(new URLRequest(data));
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
		private function onOpenImageError(e:IOErrorEvent)
		{
			while(this.icon1.numChildren > 0)
				this.icon1.removeChildAt(0);
		}
		
		private function onOpenImageCompleted(e:Event)
		{
			var bmp:DisplayObject = e.currentTarget.content as DisplayObject;						
			this.icon1.addChild(bmp);
		}
	}
	
}
