A few assumptions made:

I have included a TestData class that will create my models for me, I am using this in place of services as I assume these will be established in the program already.

Things to improve given more time:

Replace TestData.cs with relevant services to call data from a DB or Cache.
Improve the model deisng to include object id's so I don't need to reference copies of the objects (i.e copies of lists of objects in MeasurementSystemViewModel.cs).
Design of the UI is functional but not good looking.
Return specific failure exceptions from converters when incorrect method signature is used.
Implement a validation system when creating measurement system.

General design comments:

Using IMultiValueConverter for the area and distance converters as this will allow usage in the view for the other forms.