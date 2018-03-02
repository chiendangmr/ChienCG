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
	import flash.display.Loader;
	import flash.events.IOErrorEvent;
	import flash.display.DisplayObject;
		
	public class BongDa_DoiHinh442ChuDen extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:UILoader = null;
		public var image:MovieClip;
		private var request:URLRequest = null;
		
		public var doibong:TextField = new TextField();
		public var sododoihinh:TextField = new TextField();
		public var vitriNumber1:TextField = new TextField();
		public var vitriNumber2:TextField = new TextField();
		public var vitriNumber3:TextField = new TextField();
		public var vitriNumber4:TextField = new TextField();
		public var vitriNumber5:TextField = new TextField();
		public var vitriNumber6:TextField = new TextField();
		public var vitriNumber7:TextField = new TextField();
		public var vitriNumber8:TextField = new TextField();
		public var vitriNumber9:TextField = new TextField();
		public var vitriNumber10:TextField = new TextField();
		public var vitriNumber11:TextField = new TextField();
		public var vitriName1:TextField = new TextField();
		public var vitriName2:TextField = new TextField();
		public var vitriName3:TextField = new TextField();	
		public var vitriName4:TextField = new TextField();
		public var vitriName5:TextField = new TextField();
		public var vitriName6:TextField = new TextField();
		public var vitriName7:TextField = new TextField();	
		public var vitriName8:TextField = new TextField();
		public var vitriName9:TextField = new TextField();
		public var vitriName10:TextField = new TextField();
		public var vitriName11:TextField = new TextField();	
						
		public function BongDa_DoiHinh442ChuDen() {
			// constructor code
			super();							
			this.txtGroup.addChild(doibong);	
			this.txtGroup.addChild(sododoihinh);
			this.txtGroup.addChild(vitriNumber1);
			this.txtGroup.addChild(vitriNumber2);	
			this.txtGroup.addChild(vitriNumber3);
			this.txtGroup.addChild(vitriNumber4);
			this.txtGroup.addChild(vitriNumber5);	
			this.txtGroup.addChild(vitriNumber6);
			this.txtGroup.addChild(vitriNumber7);
			this.txtGroup.addChild(vitriNumber8);	
			this.txtGroup.addChild(vitriNumber9);
			this.txtGroup.addChild(vitriNumber10);
			this.txtGroup.addChild(vitriNumber11);	
			this.txtGroup.addChild(vitriName1);			
			this.txtGroup.addChild(vitriName2);
			this.txtGroup.addChild(vitriName3);
			this.txtGroup.addChild(vitriName4);	
			this.txtGroup.addChild(vitriName5);			
			this.txtGroup.addChild(vitriName6);
			this.txtGroup.addChild(vitriName7);
			this.txtGroup.addChild(vitriName8);	
			this.txtGroup.addChild(vitriName9);			
			this.txtGroup.addChild(vitriName10);
			this.txtGroup.addChild(vitriName11);
			this.txtGroup.addChild(icon1);
			//this.txtGroup.addChild(image);
			
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
			xmlStr +=Add(xmlStr, "sododoihinh", sododoihinh);
			xmlStr +=Add(xmlStr, "vitriNumber1", vitriNumber1);
			xmlStr +=Add(xmlStr, "vitriNumber2", vitriNumber2);
			xmlStr +=Add(xmlStr, "vitriNumber3", vitriNumber3);
			xmlStr +=Add(xmlStr, "vitriNumber4", vitriNumber4);	
			xmlStr +=Add(xmlStr, "vitriNumber5", vitriNumber5);
			xmlStr +=Add(xmlStr, "vitriNumber6", vitriNumber6);
			xmlStr +=Add(xmlStr, "vitriNumber7", vitriNumber7);
			xmlStr +=Add(xmlStr, "vitriNumber8", vitriNumber8);
			xmlStr +=Add(xmlStr, "vitriNumber9", vitriNumber9);
			xmlStr +=Add(xmlStr, "vitriNumber10", vitriNumber10);	
			xmlStr +=Add(xmlStr, "vitriNumber11", vitriNumber11);
			xmlStr +=Add(xmlStr, "vitriName1", vitriName1);
			xmlStr +=Add(xmlStr, "vitriName2", vitriName2);
			xmlStr +=Add(xmlStr, "vitriName3", vitriName3);	
			xmlStr +=Add(xmlStr, "vitriName4", vitriName4);
			xmlStr +=Add(xmlStr, "vitriName5", vitriName5);
			xmlStr +=Add(xmlStr, "vitriName6", vitriName6);
			xmlStr +=Add(xmlStr, "vitriName7", vitriName7);
			xmlStr +=Add(xmlStr, "vitriName8", vitriName8);
			xmlStr +=Add(xmlStr, "vitriName9", vitriName9);
			xmlStr +=Add(xmlStr, "vitriName10", vitriName10);
			xmlStr +=Add(xmlStr, "vitriName11", vitriName11);
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
					case "sododoihinh".toLowerCase():
						this.sododoihinh.text = data.toUpperCase();
						break;
					case "vitriNumber1".toLowerCase():
						this.vitriNumber1.text = data.toUpperCase();
						break;
					case "vitriNumber2".toLowerCase():
						this.vitriNumber2.text = data.toUpperCase();
						break;
					case "vitriNumber3".toLowerCase():
						this.vitriNumber3.text = data.toUpperCase();
						break;
					case "vitriNumber4".toLowerCase():
						this.vitriNumber4.text = data.toUpperCase();
						break;	
					case "vitriNumber5".toLowerCase():
						this.vitriNumber5.text = data.toUpperCase();
						break;
					case "vitriNumber6".toLowerCase():
						this.vitriNumber6.text = data.toUpperCase();
						break;
					case "vitriNumber7".toLowerCase():
						this.vitriNumber7.text = data.toUpperCase();
						break;
					case "vitriNumber8".toLowerCase():
						this.vitriNumber8.text = data.toUpperCase();
						break;					
					case "vitriNumber9".toLowerCase():
						this.vitriNumber9.text = data.toUpperCase();
						break;
					case "vitriNumber10".toLowerCase():
						this.vitriNumber10.text = data.toUpperCase();
						break;
					case "vitriNumber11".toLowerCase():
						this.vitriNumber11.text = data.toUpperCase();
						break;
					case "vitriName1".toLowerCase():
						this.vitriName1.text = data.toUpperCase();
						break;
					case "vitriName2".toLowerCase():
						this.vitriName2.text = data.toUpperCase();
						break;
					case "vitriName3".toLowerCase():
						this.vitriName3.text = data.toUpperCase();
						break;	
					case "vitriName4".toLowerCase():
						this.vitriName4.text = data.toUpperCase();
						break;
					case "vitriName5".toLowerCase():
						this.vitriName5.text = data.toUpperCase();
						break;
					case "vitriName6".toLowerCase():
						this.vitriName6.text = data.toUpperCase();
						break;
					case "vitriName7".toLowerCase():
						this.vitriName7.text = data.toUpperCase();
						break;	
					case "vitriName8".toLowerCase():
						this.vitriName8.text = data.toUpperCase();
						break;
					case "vitriName9".toLowerCase():
						this.vitriName9.text = data.toUpperCase();
						break;
					case "vitriName10".toLowerCase():
						this.vitriName10.text = data.toUpperCase();
						break;
					case "vitriName11".toLowerCase():
						this.vitriName11.text = data.toUpperCase();
						break;	
					case "icon1".toLowerCase():						
						request = new URLRequest(data);
						this.icon1.load(request);
						break;
					case "image".toLowerCase():						
						request = new URLRequest(data);
						var file:Loader = new Loader();
						file.contentLoaderInfo.addEventListener(Event.COMPLETE, onOpenImageCompleted);
						file.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onOpenImageError);
						file.load(request);
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
		private function ClearImage()
		{
			while(this.image.numChildren > 0)
				this.image.removeChildAt(0);
		}
		private function onOpenImageError(e:IOErrorEvent)
		{
			this.ClearImage();
		}
		
		private function onOpenImageCompleted(e:Event)
		{
			var bmp:DisplayObject = e.currentTarget.content as DisplayObject;		
			
			bmp.x = bmp.y = 0;
			bmp.width = 1920;
			bmp.height = 1080;					
			
			this.image.addChild(bmp);
			this.image.x=this.image.y=0;
			this.image.width=1920;
			this.image.height=1080;
		}
	}
	
}
