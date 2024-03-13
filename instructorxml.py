import xml.etree.ElementTree as ET # https://docs.python.org/3/library/xml.etree.elementtree.html
# https://docs.python.org/3/library/xml.etree.elementtree.html#building-xml-documents
root = ET.Element("Root") # XML Root

# For the instructor table
# instructorID, firstName, lastName, rank, univeristy, faulty
data = ET.SubElement(root, "instructor")
item1 = ET.SubElement(data, "Item") # <Item> and </Item>
item1.attrib["instructor"] = "1"
id1 = ET.SubElement(item1, "instructorID")
id1.text = "600000"
name1_1 = ET.SubElement(item1, "firstName")
name1_1.text = "John"
name1_2 = ET.SubElement(item1, "lastName")
name1_2.text = "Cena"
rank1 = ET.SubElement(item1, "rank")
rank1.text = "Professor"
age1 = ET.SubElement(item1, "age")
age1.text = "46"
uni1 = ET.SubElement(item1, "university")
uni1.text = "MacEwan University"
faculty1 = ET.SubElement(item1, "faculty")
faculty1.text = "Faculty of Arts and Science"
gender1 = ET.SubElement(item1, "gender")
gender1.text = "male"

item2 = ET.SubElement(data, "Item") 
item2.attrib["instructor"] = "2"
id1 = ET.SubElement(item2, "instructorID")
id1.text = "600001"
name2_1 = ET.SubElement(item2, "firstName")
name2_1.text = "Chael"
name2_2 = ET.SubElement(item2, "lastName")
name2_2.text = "Sonnen"
rank2 = ET.SubElement(item2, "rank")
rank2.text = "Professor"
age2 = ET.SubElement(item2, "age")
age2.text = "50"
uni2 = ET.SubElement(item2, "university")
uni2.text = "MacEwan University"
faculty2 = ET.SubElement(item2, "faculty")
faculty2.text = "Faculty of Phsyical Education"
gender2 = ET.SubElement(item2, "gender")
gender2.text = "male"







tree = ET.ElementTree(root)
tree.write("instructor.xml", encoding="utf-8", xml_declaration=True)
