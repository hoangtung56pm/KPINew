<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns="urn:schemas-microsoft-com:office:spreadsheet"
xmlns:o="urn:schemas-microsoft-com:office:office"
xmlns:x="urn:schemas-microsoft-com:office:excel"
xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
xmlns:html="http://www.w3.org/TR/REC-html40"
xmlns:myObj="urn:ms-kb">

	<xsl:template match="/NewDataSet">
		<Workbook>
			<Styles>
				<Style ss:ID="Default" ss:Name="Normal">
					<Alignment ss:Vertical="Bottom"/>
					<Borders/>
					<Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
					<Interior/>
					<NumberFormat/>
					<Protection/>
				</Style>
				<Style ss:ID="s75">
          <Alignment ss:Horizontal="Left" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#000000"/>
				</Style>
				<Style ss:ID="s87">
					<Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#000000"/>
				</Style>
				<Style ss:ID="s110">
					<Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
					<Borders/>
					<Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#000000"/>
					<NumberFormat ss:Format="@"/>
				</Style>
				<Style ss:ID="s111">
					<Alignment ss:Vertical="Center" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#FF0000"
					 ss:Bold="1"/>
					<Interior ss:Color="#FFFF00" ss:Pattern="Solid"/>
					<NumberFormat ss:Format="0"/>
				</Style>
				<Style ss:ID="s112">
					<Alignment ss:Vertical="Center" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#FF0000"
					 ss:Bold="1"/>
					<Interior ss:Color="#FFFF00" ss:Pattern="Solid"/>
					<NumberFormat ss:Format="@"/>
				</Style>
				<Style ss:ID="s119">
					<Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#000000"/>
          <NumberFormat ss:Format="0.0"/>
				</Style>

			</Styles>

			<Worksheet>
				<xsl:attribute name="ss:Name">Sheet1</xsl:attribute>
				<Table  x:FullColumns="1" x:FullRows="1" ss:StyleID="s87">
          <Column ss:StyleID="s87" ss:AutoFitWidth="0" ss:Width="150"/>
					<Column ss:StyleID="s87" ss:AutoFitWidth="0" ss:Width="150"/>
					<Column ss:StyleID="s87" ss:AutoFitWidth="0" ss:Width="100"/>
          <Column ss:StyleID="s87" ss:AutoFitWidth="0" ss:Width="100"/>
          <Column ss:StyleID="s87" ss:AutoFitWidth="0" ss:Width="100"/>
					<Column ss:StyleID="s87" ss:AutoFitWidth="0" ss:Width="200"/>
          <Column ss:StyleID="s87" ss:AutoFitWidth="0" ss:Width="200"/>
          <Column ss:StyleID="s87" ss:AutoFitWidth="0" ss:Width="200"/>
					<Row ss:AutoFitHeight="0" ss:Height="68.25">
            <Cell ss:StyleID="s111">
              <Data ss:Type="String">Phòng</Data>
            </Cell>
						<Cell ss:StyleID="s111">
							<Data ss:Type="String">Tên công việc</Data>
						</Cell>
            <Cell ss:StyleID="s112">
              <Data ss:Type="String">Ngày bắt đầu</Data>
            </Cell>
            <Cell ss:StyleID="s112">
              <Data ss:Type="String">Ngày kết thúc</Data>
            </Cell>
						<Cell ss:StyleID="s111">
							<Data ss:Type="String">Tỷ trọng %</Data>
						</Cell>
						<Cell ss:StyleID="s112">
							<Data ss:Type="String">Số liệu cam kết</Data>
						</Cell>

						<Cell ss:StyleID="s112">
							<Data ss:Type="String">Yêu cầu hỗ trợ</Data>
						</Cell>
            <Cell ss:StyleID="s112">
              <Data ss:Type="String">Người tham gia</Data>
            </Cell>
          </Row>
					<xsl:apply-templates select="Table"></xsl:apply-templates>
				</Table>
			</Worksheet>
		</Workbook>
	</xsl:template>

	<xsl:template match="Table">
		<Row>
      <Cell ss:StyleID="s75">
        <Data ss:Type="String">
          <xsl:value-of select="IDPhongBan"/>
        </Data>
      </Cell>
			<Cell ss:StyleID="s75">
				<Data ss:Type="String">
					<xsl:value-of select="TenCongViec"/>
				</Data>
			</Cell>
      <Cell ss:StyleID="s75">
        <Data ss:Type="String">
          <xsl:value-of select="NgayBatDau"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s75">
        <Data ss:Type="String">
          <xsl:value-of select="NgayKetThuc"/>
        </Data>
      </Cell>
			<Cell ss:StyleID="s119">
				<Data ss:Type="Number">
					<xsl:value-of select="TyTrongCV"/>
				</Data>
			</Cell>
			<Cell ss:StyleID="s75">
				<Data ss:Type="String">
					<xsl:value-of select="SoLieuCamKet"/>
				</Data>
			</Cell>

			<Cell ss:StyleID="s75">
				<Data ss:Type="String">
					<xsl:value-of select="YeuCauHoTro"/>
				</Data>
			</Cell>
      <Cell ss:StyleID="s75">
        <Data ss:Type="String">
          <xsl:value-of select="NguoiThamGia"/>
        </Data>
      </Cell>
		</Row>
	</xsl:template>
</xsl:stylesheet>