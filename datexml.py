import xml.etree.ElementTree as ET # https://docs.python.org/3/library/xml.etree.elementtree.html
# https://docs.python.org/3/library/xml.etree.elementtree.html#building-xml-documents
root = ET.Element("Root") # XML Root

# For the date table
# dateID, semester, year
data = ET.SubElement(root, "date")
item1 = ET.SubElement(data, "Item") # <Item> and </Item>
item1.attrib["date"] = "1"
id1 = ET.SubElement(item1, "dateID")
id1.text = "600000"
semester1 = ET.SubElement(item1, "semester")
semester1.text = "Fall"
year1 = ET.SubElement(item1, "year")
year1.text = "2015"


item2 = ET.SubElement(data, "Item") # <Item> and </Item>
item2.attrib["date"] = "2"
id2 = ET.SubElement(item2, "dateID")
id2.text = "600001"
semester2 = ET.SubElement(item2, "semester")
semester2.text = "Fall"
year2 = ET.SubElement(item2, "year")
year2.text = "2016"

tree = ET.ElementTree(root)
tree.write("date.xml", encoding="utf-8", xml_declaration=True)