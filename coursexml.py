import xml.etree.ElementTree as ET # https://docs.python.org/3/library/xml.etree.elementtree.html
# https://docs.python.org/3/library/xml.etree.elementtree.html#building-xml-documents
root = ET.Element("Root") # XML Root

# For the course table
# courseID, department, faculty, university
data = ET.SubElement(root, "course")

item1 = ET.SubElement(data, "Item") # <Item> and </Item>
item1.attrib["course"] = "1"
id1 = ET.SubElement(item1, "courseID")
id1.text = "600000"
department1 = ET.SubElement(item1, "department")
department1.text = "Department of Psychlogy"
faculty1 = ET.SubElement(item1, "faculty")
faculty1.text = "Arts and Science"
university1 = ET.SubElement(item1, "university")
university1.text = "MacEwan University"



item2 = ET.SubElement(data, "Item") # <Item> and </Item>
item2.attrib["student"] = "2"
id2 = ET.SubElement(item2, "courseID")
id2.text = "600001"
department2 = ET.SubElement(item2, "department")
department2.text = "Department of Mathematics"
faculty2 = ET.SubElement(item2, "faculty")
faculty2.text = "Arts and Science"
university2 = ET.SubElement(item2, "university")
university2.text = "University of Alberta"



tree = ET.ElementTree(root)
tree.write("course.xml", encoding="utf-8", xml_declaration=True)