<?xml version="1.0" encoding="utf-8"?> 

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="Categories">
		<Categories>
			<xsl:apply-templates select="Category"/>
		</Categories>
	</xsl:template>
	<xsl:template match="Category">
		<Category>
			<xsl:attribute name="Category_ID">
				<xsl:value-of select="Category_ID"/>
			</xsl:attribute>
			<xsl:attribute name="Category_Name">
				<xsl:value-of select="Category_Name"/>
			</xsl:attribute>
		</Category>
	</xsl:template>
</xsl:stylesheet>