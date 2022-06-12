<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<head>
				<link rel="stylesheet"
					  type="text/css"
					  href="css/viewrecordcss.css"/>
			</head>
			<body>
				<div>
					<table>
						<tr>
							<th>Record ID</th>
							<th>Customer ID</th>
							<th>Customer Name</th>
							<th>Order ID</th>
							<th>Product ID</th>
							<th>Product Name</th>
							<th>Quantity</th>
							<th>Total Price</th>
							<th>Payment Method</th>
							<th>Date</th>
							<th></th>
						</tr>
						<xsl:for-each select="Orders/Order">
							<tr>
								<td>
									<xsl:value-of select="Record_ID"/>
								</td>
								<td>
									<xsl:value-of select="Cust_ID"/>
								</td>
								<td>
									<xsl:value-of select="Cust_Name"/>
								</td>
								<td>
									<xsl:value-of select="Ord_ID"/>
								</td>
								<td>
									<xsl:value-of select="Prod_ID"/>
								</td>
								<td>
									<xsl:value-of select="Prod_Name"/>
								</td>
								<td>
									<xsl:value-of select="Quantity"/>
								</td>
								<td>
									<xsl:value-of select="Total_Price"/>
								</td>
								<td>
									<xsl:value-of select="Payment_Method"/>
								</td>
								<td>
									<xsl:value-of select="Date"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>