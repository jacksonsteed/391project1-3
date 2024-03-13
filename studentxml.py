import xml.etree.ElementTree as ET # https://docs.python.org/3/library/xml.etree.elementtree.html
# https://docs.python.org/3/library/xml.etree.elementtree.html#building-xml-documents
root = ET.Element("Root") # XML Root

# For the student table
# studentID, firstName, lastName, major, age, gender, university
data = ET.SubElement(root, "student")

item1 = ET.SubElement(data, "Item") # <Item> and </Item>
item1.attrib["student"] = "1"
id1 = ET.SubElement(item1, "studentID")
id1.text = "600000"
firstName1 = ET.SubElement(item1, "firstName")
firstName1.text = "Jane"
lastName1 = ET.SubElement(item1, "lastName")
lastName1.text = "Gooddall"
major1 = ET.SubElement(item1, "major")
major1.text = "Biology"
age1 = ET.SubElement(item1, "age")
age1.text = "20"
gender1 = ET.SubElement(item1, "gender")
gender1.text = "Female"
university1 = ET.SubElement(item1, "university")
university1.text = "University of Calgary"


item2 = ET.SubElement(data, "Item") # <Item> and </Item>
item2.attrib["student"] = "2"
id2 = ET.SubElement(item2, "studentID")
id2.text = "600001"
firstName2 = ET.SubElement(item2, "firstName")
firstName2.text = "Margaret"
lastName2 = ET.SubElement(item2, "lastName")
lastName2.text = "Thatcher"
major2 = ET.SubElement(item2, "major")
major2.text = "Political Science"
age2 = ET.SubElement(item2, "age")
age2.text = "20"
gender2 = ET.SubElement(item2, "gender")
gender2.text = "Female"
university2 = ET.SubElement(item2, "university")
university2.text = "University of Calgary"


tree = ET.ElementTree(root)
tree.write("student.xml", encoding="utf-8", xml_declaration=True)