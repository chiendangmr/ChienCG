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
		
	public class DavisCup_Ranking extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		
		public var rankingPosition1:TextField = new TextField();
		public var rankingPosition2:TextField = new TextField();
		public var rankingPosition3:TextField = new TextField();
		public var rankingPosition4:TextField = new TextField();
		public var rankingPosition5:TextField = new TextField();
		public var rankingPosition6:TextField = new TextField();
		public var rankingPosition7:TextField = new TextField();
		public var rankingPosition8:TextField = new TextField();
		public var rankingPosition9:TextField = new TextField();
		public var rankingPosition10:TextField = new TextField();
		public var rankingNation1:TextField = new TextField();
		public var rankingNation2:TextField = new TextField();
		public var rankingNation3:TextField = new TextField();
		public var rankingNation4:TextField = new TextField();
		public var rankingNation5:TextField = new TextField();
		public var rankingNation6:TextField = new TextField();	
		public var rankingNation7:TextField = new TextField();	
		public var rankingNation8:TextField = new TextField();
		public var rankingNation9:TextField = new TextField();	
		public var rankingNation10:TextField = new TextField();	
		public var rankingPoints1:TextField = new TextField();
		public var rankingPoints2:TextField = new TextField();
		public var rankingPoints3:TextField = new TextField();
		public var rankingPoints4:TextField = new TextField();
		public var rankingPoints5:TextField = new TextField();
		public var rankingPoints6:TextField = new TextField();	
		public var rankingPoints7:TextField = new TextField();	
		public var rankingPoints8:TextField = new TextField();
		public var rankingPoints9:TextField = new TextField();	
		public var rankingPoints10:TextField = new TextField();	
		public var rankingPlayed1:TextField = new TextField();
		public var rankingPlayed2:TextField = new TextField();
		public var rankingPlayed3:TextField = new TextField();
		public var rankingPlayed4:TextField = new TextField();
		public var rankingPlayed5:TextField = new TextField();
		public var rankingPlayed6:TextField = new TextField();	
		public var rankingPlayed7:TextField = new TextField();	
		public var rankingPlayed8:TextField = new TextField();
		public var rankingPlayed9:TextField = new TextField();	
		public var rankingPlayed10:TextField = new TextField();	
		public var rankingPrevious1:TextField = new TextField();
		public var rankingPrevious2:TextField = new TextField();
		public var rankingPrevious3:TextField = new TextField();
		public var rankingPrevious4:TextField = new TextField();
		public var rankingPrevious5:TextField = new TextField();
		public var rankingPrevious6:TextField = new TextField();	
		public var rankingPrevious7:TextField = new TextField();	
		public var rankingPrevious8:TextField = new TextField();
		public var rankingPrevious9:TextField = new TextField();	
		public var rankingPrevious10:TextField = new TextField();	
						
		public function DavisCup_Ranking() {
			// constructor code
			super();							
			this.txtGroup.addChild(rankingPosition1);	
			this.txtGroup.addChild(rankingPosition2);
			this.txtGroup.addChild(rankingPosition3);
			this.txtGroup.addChild(rankingPosition4);	
			this.txtGroup.addChild(rankingPosition5);
			this.txtGroup.addChild(rankingPosition6);
			this.txtGroup.addChild(rankingPosition7);	
			this.txtGroup.addChild(rankingPosition8);
			this.txtGroup.addChild(rankingPosition9);
			this.txtGroup.addChild(rankingPosition10);	
			this.txtGroup.addChild(rankingNation1);
			this.txtGroup.addChild(rankingNation2);
			this.txtGroup.addChild(rankingNation3);	
			this.txtGroup.addChild(rankingNation4);			
			this.txtGroup.addChild(rankingNation5);
			this.txtGroup.addChild(rankingNation6);
			this.txtGroup.addChild(rankingNation7);			
			this.txtGroup.addChild(rankingNation8);
			this.txtGroup.addChild(rankingNation9);
			this.txtGroup.addChild(rankingNation10);
			this.txtGroup.addChild(rankingPoints1);
			this.txtGroup.addChild(rankingPoints2);
			this.txtGroup.addChild(rankingPoints3);	
			this.txtGroup.addChild(rankingPoints4);			
			this.txtGroup.addChild(rankingPoints5);
			this.txtGroup.addChild(rankingPoints6);
			this.txtGroup.addChild(rankingPoints7);			
			this.txtGroup.addChild(rankingPoints8);
			this.txtGroup.addChild(rankingPoints9);
			this.txtGroup.addChild(rankingPoints10);
			this.txtGroup.addChild(rankingPlayed1);
			this.txtGroup.addChild(rankingPlayed2);
			this.txtGroup.addChild(rankingPlayed3);	
			this.txtGroup.addChild(rankingPlayed4);			
			this.txtGroup.addChild(rankingPlayed5);
			this.txtGroup.addChild(rankingPlayed6);
			this.txtGroup.addChild(rankingPlayed7);			
			this.txtGroup.addChild(rankingPlayed8);
			this.txtGroup.addChild(rankingPlayed9);
			this.txtGroup.addChild(rankingPlayed10);
			this.txtGroup.addChild(rankingPrevious1);
			this.txtGroup.addChild(rankingPrevious2);
			this.txtGroup.addChild(rankingPrevious3);	
			this.txtGroup.addChild(rankingPrevious4);			
			this.txtGroup.addChild(rankingPrevious5);
			this.txtGroup.addChild(rankingPrevious6);
			this.txtGroup.addChild(rankingPrevious7);			
			this.txtGroup.addChild(rankingPrevious8);
			this.txtGroup.addChild(rankingPrevious9);
			this.txtGroup.addChild(rankingPrevious10);
			
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
			xmlStr +=Add(xmlStr, "rankingPosition1", rankingPosition1);
			xmlStr +=Add(xmlStr, "rankingPosition2", rankingPosition2);
			xmlStr +=Add(xmlStr, "rankingPosition3", rankingPosition3);
			xmlStr +=Add(xmlStr, "rankingPosition4", rankingPosition4);
			xmlStr +=Add(xmlStr, "rankingPosition5", rankingPosition5);
			xmlStr +=Add(xmlStr, "rankingPosition6", rankingPosition6);	
			xmlStr +=Add(xmlStr, "rankingPosition7", rankingPosition7);
			xmlStr +=Add(xmlStr, "rankingPosition8", rankingPosition8);
			xmlStr +=Add(xmlStr, "rankingPosition9", rankingPosition9);
			xmlStr +=Add(xmlStr, "rankingPosition10", rankingPosition10);
			xmlStr +=Add(xmlStr, "rankingNation1", rankingNation1);
			xmlStr +=Add(xmlStr, "rankingNation2", rankingNation2);	
			xmlStr +=Add(xmlStr, "rankingNation3", rankingNation3);
			xmlStr +=Add(xmlStr, "rankingNation4", rankingNation4);
			xmlStr +=Add(xmlStr, "rankingNation5", rankingNation5);
			xmlStr +=Add(xmlStr, "rankingNation6", rankingNation6);	
			xmlStr +=Add(xmlStr, "rankingNation7", rankingNation7);			
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
					case "rankingPosition1".toLowerCase():
						this.rankingPosition1.text = data.toUpperCase();
						break;
					case "rankingPosition2".toLowerCase():
						this.rankingPosition2.text = data.toUpperCase();
						break;
					case "rankingPosition3".toLowerCase():
						this.rankingPosition3.text = data.toUpperCase();
						break;
					case "rankingPosition4".toLowerCase():
						this.rankingPosition4.text = data.toUpperCase();
						break;
					case "rankingPosition5".toLowerCase():
						this.rankingPosition5.text = data.toUpperCase();
						break;
					case "rankingPosition6".toLowerCase():
						this.rankingPosition6.text = data.toUpperCase();
						break;	
					case "rankingPosition7".toLowerCase():
						this.rankingPosition7.text = data.toUpperCase();
						break;
					case "rankingPosition8".toLowerCase():
						this.rankingPosition8.text = data.toUpperCase();
						break;
					case "rankingPosition9".toLowerCase():
						this.rankingPosition9.text = data.toUpperCase();
						break;
					case "rankingPosition10".toLowerCase():
						this.rankingPosition10.text = data.toUpperCase();
						break;					
					case "rankingNation1".toLowerCase():
						this.rankingNation1.text = data.toUpperCase();
						break;
					case "rankingNation2".toLowerCase():
						this.rankingNation2.text = data.toUpperCase();
						break;
					case "rankingNation3".toLowerCase():
						this.rankingNation3.text = data.toUpperCase();
						break;
					case "rankingNation4".toLowerCase():
						this.rankingNation4.text = data.toUpperCase();
						break;
					case "rankingNation5".toLowerCase():
						this.rankingNation5.text = data.toUpperCase();
						break;
					case "rankingNation6".toLowerCase():
						this.rankingNation6.text = data.toUpperCase();
						break;	
					case "rankingNation7".toLowerCase():
						this.rankingNation7.text = data.toUpperCase();
						break;		
					case "rankingNation8".toLowerCase():
						this.rankingNation8.text = data.toUpperCase();
						break;
					case "rankingNation9".toLowerCase():
						this.rankingNation9.text = data.toUpperCase();
						break;	
					case "rankingNation10".toLowerCase():
						this.rankingNation10.text = data.toUpperCase();
						break;		
					
					case "rankingPoints1".toLowerCase():
						this.rankingPoints1.text = data.toUpperCase();
						break;
					case "rankingPoints2".toLowerCase():
						this.rankingPoints2.text = data.toUpperCase();
						break;
					case "rankingPoints3".toLowerCase():
						this.rankingPoints3.text = data.toUpperCase();
						break;
					case "rankingPoints4".toLowerCase():
						this.rankingPoints4.text = data.toUpperCase();
						break;
					case "rankingPoints5".toLowerCase():
						this.rankingPoints5.text = data.toUpperCase();
						break;
					case "rankingPoints6".toLowerCase():
						this.rankingPoints6.text = data.toUpperCase();
						break;	
					case "rankingPoints7".toLowerCase():
						this.rankingPoints7.text = data.toUpperCase();
						break;		
					case "rankingPoints8".toLowerCase():
						this.rankingPoints8.text = data.toUpperCase();
						break;
					case "rankingPoints9".toLowerCase():
						this.rankingPoints9.text = data.toUpperCase();
						break;	
					case "rankingPoints10".toLowerCase():
						this.rankingNation10.text = data.toUpperCase();
						break;		
					
					case "rankingPlayed1".toLowerCase():
						this.rankingPlayed1.text = data.toUpperCase();
						break;
					case "rankingPlayed2".toLowerCase():
						this.rankingPlayed2.text = data.toUpperCase();
						break;
					case "rankingPlayed3".toLowerCase():
						this.rankingPlayed3.text = data.toUpperCase();
						break;
					case "rankingPlayed4".toLowerCase():
						this.rankingPlayed4.text = data.toUpperCase();
						break;
					case "rankingPlayed5".toLowerCase():
						this.rankingPlayed5.text = data.toUpperCase();
						break;
					case "rankingPlayed6".toLowerCase():
						this.rankingPlayed6.text = data.toUpperCase();
						break;	
					case "rankingPlayed7".toLowerCase():
						this.rankingPlayed7.text = data.toUpperCase();
						break;		
					case "rankingPlayed8".toLowerCase():
						this.rankingPlayed8.text = data.toUpperCase();
						break;
					case "rankingPlayed9".toLowerCase():
						this.rankingPlayed9.text = data.toUpperCase();
						break;	
					case "rankingPlayed10".toLowerCase():
						this.rankingPlayed10.text = data.toUpperCase();
						break;		
					
					case "rankingPrevious1".toLowerCase():
						this.rankingPrevious1.text = data.toUpperCase();
						break;
					case "rankingPrevious2".toLowerCase():
						this.rankingPrevious2.text = data.toUpperCase();
						break;
					case "rankingPrevious3".toLowerCase():
						this.rankingPrevious3.text = data.toUpperCase();
						break;
					case "rankingPrevious4".toLowerCase():
						this.rankingPrevious4.text = data.toUpperCase();
						break;
					case "rankingPrevious5".toLowerCase():
						this.rankingPrevious5.text = data.toUpperCase();
						break;
					case "rankingPrevious6".toLowerCase():
						this.rankingPrevious6.text = data.toUpperCase();
						break;	
					case "rankingPrevious7".toLowerCase():
						this.rankingPrevious7.text = data.toUpperCase();
						break;		
					case "rankingPrevious8".toLowerCase():
						this.rankingPrevious8.text = data.toUpperCase();
						break;
					case "rankingPrevious9".toLowerCase():
						this.rankingPrevious9.text = data.toUpperCase();
						break;	
					case "rankingPrevious10".toLowerCase():
						this.rankingPrevious10.text = data.toUpperCase();
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
