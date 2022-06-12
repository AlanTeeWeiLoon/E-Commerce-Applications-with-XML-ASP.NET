<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<head>
				<link rel="stylesheet"
					  type="text/css"
					  href="css/viewcategorycss.css"/>
			</head>
			<body>
				<div class="viewcategorytable">
				<table class="viewcategorytable">
					<tr>
						<th>Category ID</th>
						<th>Category Name</th>
						<th>Category Description</th>
						<th>Action</th>
					</tr>
					<xsl:for-each select="Categories/category">
							<tr>
								<td>
									<xsl:value-of select="Category_ID"/>
								</td>
								<td>
									<xsl:value-of select="Category_Name"/>
								</td>
								<td>
									<xsl:value-of select="Category_Description"/>
								</td>
								<td>
									<xsl:variable name="cid" select="Category_ID"/>
									<input type="button" value="EDIT" onclick="window.location='EditCategory.aspx?catid={$cid}'" style="background:darkgrey" />

								</td>
							</tr>
					</xsl:for-each>
				</table>
				</div>
			</body>
			<script type="text/javascript">
				function jsV() {
				var jsVar = '<xsl:value-of select="Category_ID"/>';
				return jsVar;
				}
			</script>
		</html>
	</xsl:template>
</xsl:stylesheet>