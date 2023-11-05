using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace TimelineUtility
{
    [CustomEditor(typeof(TimelineUtilityTester))]
    public class TimelineUtilityTesterEditor : Editor
    {
        private TimelineUtilityTester tester;

        public override VisualElement CreateInspectorGUI()
        {
            tester = (TimelineUtilityTester)target;
        
            VisualElement root = new VisualElement();
            VisualElement propertiesRoot = CreateProperties();
            VisualElement buttons = CreateButtons();

            root.Add(propertiesRoot);
            root.Add(buttons);

            return root;
        }

        private VisualElement CreateProperties()
        {
            VisualElement propertiesRoot = new VisualElement();
            
            SerializedObject so = new SerializedObject(tester);
            
            SerializedProperty eventName = so.FindProperty("eventName");
            SerializedProperty eventTrackName = so.FindProperty("eventTrackName");
            SerializedProperty eventDescription = so.FindProperty("eventDescription");
            
            SerializedProperty processName = so.FindProperty("processName");
            SerializedProperty processTrackName = so.FindProperty("processTrackName");
            SerializedProperty processDescription = so.FindProperty("processDescription");

            propertiesRoot.Add(new PropertyField(eventName));
            propertiesRoot.Add(new PropertyField(eventTrackName));
            propertiesRoot.Add(new PropertyField(eventDescription));
            
            propertiesRoot.Add(new PropertyField(processName));
            propertiesRoot.Add(new PropertyField(processTrackName));
            propertiesRoot.Add(new PropertyField(processDescription));

            return propertiesRoot;
        }

        private VisualElement CreateButtons()
        {
            VisualElement buttonsRoot = new VisualElement();

            buttonsRoot.style.alignItems = Align.Center;

            Button addEventButton = new Button(OnAddEventClick);
            Button startProcessButton = new Button(OnAddProcessClick);
            Button finishProcessButton = new Button(OnFinishProcessClick);

            addEventButton.text = "Add Event";
            startProcessButton.text = "Start Process";
            finishProcessButton.text = "Finish Process";

            addEventButton.style.width = 200;
            startProcessButton.style.width = 200;
            finishProcessButton.style.width = 200;
            
            buttonsRoot.Add(addEventButton);
            buttonsRoot.Add(startProcessButton);
            buttonsRoot.Add(finishProcessButton);
            
            return buttonsRoot;
        }

        private void OnFinishProcessClick() => tester.FinishProcess();
        private void OnAddProcessClick() => tester.AddProcess();
        private void OnAddEventClick() => tester.AddEvent();
    }
}