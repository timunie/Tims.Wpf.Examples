# MahApps.Metro.Examples

-------

## Hamburgermenu sample using CompositeCollection
This sample demonstrates a few advanced possibilities of the cool [MahApps HamburgerMenu](https://mahapps.com). 

### Features
- Uses `CompositeCollection` to show normal `HamburgerMenuItem` together with a dynamic `OservableCollection`
- Uses a custom `DataTemplateSelector` to provide different apperance for the items
- Uses different `DataTemplates`
- Uses `Binding` to show/hide some items

### Preview
![](res/HamburgerMenuCompositeCollection.png)

--------------------------------------------------------------

## Hamburgermenu with Pane that opens automatically on MouseOver

Attention: This sample should only show that it is possible to do it with a custom `ControlTemplate`. It may be a bad UX / UI. Please think about it before you implement this in your App. 

### Features
- `HamburgerMenu` opens when the user moves the cursor over the items. 

### Preview
![](res/HamburgerMenuAutoOpenClose.gif)

--------------------------------------------------------------

## Custom Style for DataGridCell with Trigger

### Features
- A `Button` shows up when the `DataGridCell` becomes the focus
- For now the cell will start editing mode when you click the button

### Preview
![](res/DataGridCellStyle_FocusTrigger.gif)